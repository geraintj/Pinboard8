using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PinboardApi.Model;

namespace PinboardApi
{
    interface IPinboardApiWrapper
    {
        DateTime GetTimeOfLatestUpdate();

        List<Bookmark> GetAllBookmarks();
        List<Bookmark> GetBookmarksSince(DateTime date);
        void AddBookmark(Bookmark newBookmark);
        void DeleteBookmark(string url);

        List<Tag> GetTags();
        void RenameTag(string newTag, string oldTag);
        void DeleteTag(string tag);
    }
}
