using ReadLater.Data.Dtos;
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
    public class UserBookmarkController : Controller
    {
        #region Fields
        private readonly IUserBookmarkService _userBookmarkService;
        private ApplicationUserManager _userManager;
        #endregion

        #region Ctor
        public UserBookmarkController(IUserBookmarkService userBookmarkService)
        {
            _userBookmarkService = userBookmarkService;
        }
        #endregion

        #region Methods

        [HttpPost]
        [Route("addUserBookmark")]
        public ActionResult AddUserBookmark(AddUserBookmark userBookmark)
        {
            if (ModelState.IsValid)
            {
                _userBookmarkService.AddUserBookmark(userBookmark);
                return RedirectToAction("Index");
            }
            return View(userBookmark);
        }

        //GET /UserBookmark/GetUserBookmarks?userId
        [HttpGet]
        public ActionResult GetUserBookmarks(Guid userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<UserBookmarkDto> userBookmarks = _userBookmarkService.GetUserBookmarks(userId);
            if (userBookmarks == null)
            {
                return HttpNotFound();
            }
            return Json(userBookmarks, JsonRequestBehavior.AllowGet);
        }

        //GET /UserBookmark/GetMostClickedBookmarks?userId
        [HttpGet]
        public ActionResult GetMostClickedBookmarks(Guid userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<UserBookmarkDto> userBookmarks = _userBookmarkService.GetMostClickedBookmarks(userId);
            if (userBookmarks == null)
            {
                return HttpNotFound();
            }
            return Json(userBookmarks, JsonRequestBehavior.AllowGet);
        }

        ////GET /UserBookmark/GetMostRecentBookmarks?userId
        [HttpGet]
        public ActionResult GetMostRecentBookmarks(Guid userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<UserBookmarkDto> userBookmarks = _userBookmarkService.GetMostRecentBookmarks(userId);
            if (userBookmarks == null)
            {
                return HttpNotFound();
            }
            return Json(userBookmarks, JsonRequestBehavior.AllowGet);
        }

        //GET /UserBookmark/GetMostPopularBookmarksForToday?userId
        [HttpGet]
        public ActionResult GetMostPopularBookmarksForToday(Guid userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<UserBookmarkDto> userBookmarks = _userBookmarkService.GetMostPopularBookmarksForToday(userId);
            if (userBookmarks == null)
            {
                return HttpNotFound();
            }
            return Json(userBookmarks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("clickedBookmark")]
        public ActionResult ClickedBookmark(AddUserBookmark userBookmark)
        {
            if (ModelState.IsValid)
            {
                _userBookmarkService.ClickedBookmark(userBookmark);
                return RedirectToAction("Index");
            }

            return View(userBookmark);
        }

        //POST /UserBookmark/ShareWithFriend + body
        [HttpPost]
        public ActionResult ShareWithFriend(UserFriendDto userFriendDto)
        {
            if (ModelState.IsValid)
            {
                _userBookmarkService.ShareWithFriend(userFriendDto);
                return RedirectToAction("Index");
            }

            return View(userFriendDto);
        }

        #endregion
    }
}
