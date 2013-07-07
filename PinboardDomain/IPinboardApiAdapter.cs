using System;
using System.Threading.Tasks;
using PinboardDomain.Model;

namespace PinboardDomain
{
    interface IPinboardApiWrapper
    {
        Task<DateTime> GetTimeOfLatestUpdateAsync();

        Task GetAllBookmarksAsync();
        Task GetBookmarksSinceAsync(DateTime date);
        void AddBookmark(Bookmark newBookmark);
        void DeleteBookmark(string url);

        Task GetTagsAsync();
        void RenameTag(string newTag, string oldTag);
        void DeleteTag(string tag);
    }
}
