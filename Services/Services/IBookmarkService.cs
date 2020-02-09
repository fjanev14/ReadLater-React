using System.Collections.Generic;
using ReadLater.Entities;

namespace ReadLater.Services
{
    public interface IBookmarkService
    {
        Bookmark CreateBookmark(Bookmark bookmark);
        List<Bookmark> GetBookmarks(string category);
        bool UpdateBookmark(Bookmark bookmark);
        void DeleteBookmark(Bookmark bookmark);
        Bookmark GetBookmark(int ID);
    }
}