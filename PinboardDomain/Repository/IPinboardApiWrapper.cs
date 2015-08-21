using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PinboardDomain.Model;

namespace PinboardDomain.Repository
{
    public interface IPinboardApiWrapper
    {
        Task<DateTime> GetTimeOfLatestUpdateAsync();

        Task<ObservableCollection<IBookmark>> GetAllBookmarksAsync();
        List<Bookmark> GetAllBookmarks();
        Task<ObservableCollection<IBookmark>> GetBookmarksSinceAsync(DateTime date);
        Task<ObservableCollection<IBookmark>> GetRecentBookmarks();
        Task<ObservableCollection<IBookmark>> GetTaggedBookmarks(string tagName);
        Task<Bookmark> GetBookmarkAsync(string url);
  
        void AddBookmark(Bookmark newBookmark);
        void DeleteBookmark(string url);
        void UpdateBookmark(Bookmark editBookmark);

        Task<ObservableCollection<ITag>> GetTagsAsync();
        void RenameTag(string newTag, string oldTag);
        void DeleteTag(string tag);
    }
}
