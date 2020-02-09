using ReadLater.Data.Dtos;
using ReadLater.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Services
{
    public interface IUserBookmarkService
    {
        void AddUserBookmark(AddUserBookmark userBookmark);

        List<UserBookmarkDto> GetUserBookmarks(Guid userId);

        List<UserBookmarkDto> GetMostClickedBookmarks(Guid userId);

        List<UserBookmarkDto> GetMostRecentBookmarks(Guid userId);

        List<UserBookmarkDto> GetMostPopularBookmarksForToday(Guid userId);

        void ClickedBookmark(AddUserBookmark userBookmark);

        void ShareWithFriend(UserFriendDto userFriend);
    }
}
