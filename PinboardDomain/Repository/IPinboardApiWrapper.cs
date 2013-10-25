using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PinboardDomain.Model;

namespace PinboardDomain.Repository
{
    public interface IPinboardApiWrapper
    {
        Task<DateTime> GetTimeOfLatestUpdateAsync();

        Task<ObservableCollection<Bookmark>> GetAllBookmarksAsync();
        Task<ObservableCollection<Bookmark>> GetBookmarksSinceAsync(DateTime date);
        void AddBookmark(Bookmark newBookmark);
        void DeleteBookmark(string url);

        Task<ObservableCollection<ITag>> GetTagsAsync();
        void RenameTag(string newTag, string oldTag);
        void DeleteTag(string tag);
    }
}
