using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinboardApi.Model;

namespace PinboardApi
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
