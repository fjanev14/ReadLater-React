using MVC.Cors;
using ReadLater.Entities;
using ReadLater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [AllowCrossSite]
    public class BookmarkController : Controller
    {
        #region Fields
        IBookmarkService _bookmarkService;
        #endregion

        #region Ctor
        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("getBookmarks")]
        public ActionResult GetBookmarks(string bookmarks)
        {
            var bookmarksList = _bookmarkService.GetBookmarks(bookmarks);
            return Json(bookmarksList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("getBookmark")]
        public ActionResult GetBookmark(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmark(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
         return Json(bookmark, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("deleteBookmark")]
        [AllowCrossSiteJson]
        public ActionResult DeleteBookmark(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmark(id);
            _bookmarkService.DeleteBookmark(bookmark);

            return View(bookmark);
        }

        [HttpPost]
        [Route("createBookmark")]
        public ActionResult CreateBookmark(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        [HttpPost]
        [Route("updateBookmark")]
        public ActionResult UpdateBookmark(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }
        #endregion

    }
}
