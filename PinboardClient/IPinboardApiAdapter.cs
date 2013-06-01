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

        Task<List<Bookmark>> GetAllBookmarksAsync();
        Task<List<Bookmark>> GetBookmarksSinceAsync(DateTime date);
        void AddBookmark(Bookmark newBookmark);
        void DeleteBookmark(string url);

        Task<List<Tag>> GetTagsAsync();
        void RenameTag(string newTag, string oldTag);
        void DeleteTag(string tag);
    }
}
