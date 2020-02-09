using ReadLater.Data.Dtos;
using ReadLater.Entities;
using ReadLater.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReadLater.Services
{
    public class UserBookmarkService : IUserBookmarkService
    {
        protected IUnitOfWork _unitOfWork;

        public UserBookmarkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddUserBookmark(AddUserBookmark userBookmark)
        {
            UserBookmark1 userBookmarkEntity = new UserBookmark1();

            userBookmarkEntity.UserId = userBookmark.UserId;
            userBookmarkEntity.BookmarkId = userBookmark.BookmarkId;
            userBookmarkEntity.NumberOfClicks = 0;
            userBookmarkEntity.DateClicked = DateTime.Now;
            userBookmarkEntity.ID = Guid.NewGuid();

            _unitOfWork.Repository<UserBookmark1>().Insert(userBookmarkEntity);
            _unitOfWork.Save();
        }

        public List<UserBookmarkDto> GetUserBookmarks(Guid userId)
        {
            var userBookmarks = _unitOfWork.Repository<UserBookmark1>().Query()
                                                                      .Filter(x => x.UserId == userId)
                                                                      .Get()
                                                                      .ToList()
                                                                      .Select(x => new UserBookmarkDto
                                                                      {
                                                                          ID = x.ID,
                                                                          UserId = x.UserId,
                                                                          BookmarkId = x.BookmarkId.Value,
                                                                          BookmarkName = x.Bookmark.ShortDescription,
                                                                          BookmarkUrl = x.Bookmark.URL,
                                                                          CategoryName = x.Bookmark.Category.Name,
                                                                          DateClicked = x.DateClicked,
                                                                          NumberOfClicks = x.NumberOfClicks
                                                                      })
                                                                      .ToList();
            if (userBookmarks == null)
            {
                return new List<UserBookmarkDto>();
            }

            return userBookmarks;
        }

        public List<UserBookmarkDto> GetMostClickedBookmarks(Guid userId)
        {
            var userBookmark = _unitOfWork.Repository<UserBookmark1>().Query()
                                                                    .Filter(x => x.UserId == userId)
                                                                    .Get()
                                                                    .OrderByDescending(x => x.NumberOfClicks)
                                                                     .Select(x => new UserBookmarkDto
                                                                     {
                                                                         ID = x.ID,
                                                                         UserId = x.UserId,
                                                                         BookmarkId = x.BookmarkId.Value,
                                                                         BookmarkName = x.Bookmark.ShortDescription,
                                                                         BookmarkUrl = x.Bookmark.URL,
                                                                         CategoryName = x.Bookmark.Category.Name,
                                                                         DateClicked = x.DateClicked,
                                                                         NumberOfClicks = x.NumberOfClicks
                                                                     })
                                                                    .ToList();
            if (userBookmark == null)
            {
                return new List<UserBookmarkDto>();
            }

            return userBookmark;
        }

        public List<UserBookmarkDto> GetMostRecentBookmarks(Guid userId)
        {
            var userBookmark = _unitOfWork.Repository<UserBookmark1>().Query()
                                                                    .Filter(x => x.UserId == userId)
                                                                    .Get()
                                                                    .OrderByDescending(x => x.DateClicked)
                                                                    .ToList()
                                                                    .Select(x => new UserBookmarkDto
                                                                    {
                                                                        ID = x.ID,
                                                                        UserId = x.UserId,
                                                                        BookmarkId = x.BookmarkId.Value,
                                                                        BookmarkName = x.Bookmark.ShortDescription,
                                                                        BookmarkUrl = x.Bookmark.URL,
                                                                        CategoryName = x.Bookmark.Category.Name,
                                                                        DateClicked = x.DateClicked,
                                                                        NumberOfClicks = x.NumberOfClicks
                                                                    })
                                                                    .Take(5)
                                                                    .ToList();
            if (userBookmark == null)
            {
                return new List<UserBookmarkDto>();
            }

            return userBookmark;
        }

        public List<UserBookmarkDto> GetMostPopularBookmarksForToday(Guid userId)
        {
            var userBookmark = _unitOfWork.Repository<UserBookmark1>().Query()
                                                                    .Filter(x => x.UserId == userId)
                                                                    .Get()
                                                                    .OrderByDescending(x => x.DateClicked.Date == DateTime.Today.Date)
                                                                    .ToList()
                                                                    .Select(x => new UserBookmarkDto
                                                                    {
                                                                        ID = x.ID,
                                                                        UserId = x.UserId,
                                                                        BookmarkId = x.BookmarkId.Value,
                                                                        BookmarkName = x.Bookmark.ShortDescription,
                                                                        BookmarkUrl = x.Bookmark.URL,
                                                                        CategoryName = x.Bookmark.Category.Name,
                                                                        DateClicked = x.DateClicked,
                                                                        NumberOfClicks = x.NumberOfClicks
                                                                    })
                                                                    .Take(3)
                                                                    .ToList();

            if (userBookmark == null)
            {
                return new List<UserBookmarkDto>();
            }

            return userBookmark;
        }

        public void ClickedBookmark(AddUserBookmark userBookmark)
        {
            var loadBookmark = _unitOfWork.Repository<UserBookmark1>().Query()
                                                                   .Filter(x => x.UserId == userBookmark.UserId && x.BookmarkId == userBookmark.BookmarkId)
                                                                   .Get()
                                                                   .FirstOrDefault();
            loadBookmark.DateClicked = DateTime.Now;
            loadBookmark.NumberOfClicks += 1;

            _unitOfWork.Repository<UserBookmark1>().Update(loadBookmark);
            _unitOfWork.Save();
        }

        public void ShareWithFriend(UserFriendDto userFriend)
        {
            UserFriendBookmark1 userFriendBookmark = new UserFriendBookmark1();

            var userBookMark = GetUserBookmark(userFriend);

            userFriendBookmark.BookmarkId = userBookMark.BookmarkId;
            userFriendBookmark.DateSend = DateTime.Today;
            userFriendBookmark.FriendsIds = userFriend.FriendId;
            userFriendBookmark.URL = userFriend.ShortUrl;
            userFriendBookmark.UserId = userBookMark.UserId;
            userFriendBookmark.ObjectState = ObjectState.Modified;
            _unitOfWork.Repository<UserFriendBookmark1>().Update(userFriendBookmark);
            _unitOfWork.Save();
        }

        #region private methods
        private UserBookmark1 GetUserBookmark(UserFriendDto userFriend)
        {
            return _unitOfWork.Repository<UserBookmark1>().Query()
                                                                    .Filter(x => x.UserId == userFriend.UserId && x.BookmarkId == userFriend.BookmarkId)
                                                                    .Get()
                                                                    .FirstOrDefault();
        }

        #endregion
    }
}
