using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadLater.Entities;
using ReadLater.Repository;

namespace ReadLater.Services
{
    public class BookmarkService : IBookmarkService
    {
        protected IUnitOfWork _unitOfWork;

        public BookmarkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            bookmark.CreateDate = DateTime.Now;
            _unitOfWork.Repository<Bookmark>().Insert(bookmark);
            _unitOfWork.Save();
            return bookmark;
        }

        public List<Bookmark> GetBookmarks(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return _unitOfWork.Repository<Bookmark>().Query()
                                                        .OrderBy(l => l.OrderByDescending(b => b.CreateDate))
                                                        .Get()
                                                        .ToList();
            }
            else
            {
                return _unitOfWork.Repository<Bookmark>().Query()
                                                            .Filter(b => b.Category != null && b.Category.Name == category)
                                                            .Get()
                                                            .ToList();
            }
        }

        public bool UpdateBookmark(Bookmark bookmark)
        {
            var bookmarkValue = _unitOfWork.Repository<Bookmark>().Query()
                                                                  .Filter(x => x.ID == bookmark.ID)
                                                                  .Get()
                                                                  .FirstOrDefault();

            if (bookmarkValue == null)
            {
                return false;
            }

            bookmarkValue.CreateDate = bookmark.CreateDate;
            bookmarkValue.CategoryId = bookmark.CategoryId;
            bookmarkValue.ShortDescription = bookmark.ShortDescription;
            bookmarkValue.URL = bookmark.URL;
            bookmarkValue.ObjectState = ObjectState.Modified;
            bookmarkValue.CreateDate = DateTime.Now;
            _unitOfWork.Repository<Bookmark>().Update(bookmarkValue);
            _unitOfWork.Save();

            return true;
        }

        public void DeleteBookmark(Bookmark bookmark)
        {
            _unitOfWork.Repository<Bookmark>().Delete(bookmark);
            _unitOfWork.Save();
        }

        public Bookmark GetBookmark(int id)
        {
            return _unitOfWork.Repository<Bookmark>().Query()
                                                    .Filter(c => c.ID == id)
                                                    .Get()
                                                    .FirstOrDefault();
        }
    }
}
