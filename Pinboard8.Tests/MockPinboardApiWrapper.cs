using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinboardDomain.Model;
using PinboardDomain.Repository;

namespace Pinboard8.Tests
{
    public class MockPinboardApiWrapper : IPinboardApiWrapper
    {
        private List<Tag> _tags = new List<Tag>()
            {
                new Tag() {Name = "Tag1", Count = 1},
                new Tag() {Name = "Tag2", Count = 2},
                new Tag() {Name = "Tag3", Count = 3},
                new Tag() {Name = "Tag4", Count = 4}
            };

        private List<Bookmark> _bookmarks = new List<Bookmark>()
            {
                new Bookmark() { Title = "A bookmark, yesterday", Time = DateTime.Now.AddDays(-1).ToString(), Tags = new List<Tag>()},
                new Bookmark() { Title = "B bookmark, the day before", Time = DateTime.Now.AddDays(-2).ToString(), Tags = new List<Tag>()},
                new Bookmark() { Title = "C bookmark, last week", Time = DateTime.Now.AddDays(-7).ToString(), Tags = new List<Tag>()}
            };

        public async Task<DateTime> GetTimeOfLatestUpdateAsync()
        {
            return await GetMiddayYesterday();
        }

        public Task<ObservableCollection<IBookmark>> GetAllBookmarksAsync()
        {
            throw new NotImplementedException();
        }

        public List<Bookmark> GetAllBookmarks()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<IBookmark>> GetBookmarksSinceAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<IBookmark>> GetRecentBookmarks()
        {
            return new ObservableCollection<IBookmark>(await GetBookmarks());
        }

        public async Task<ObservableCollection<IBookmark>> GetTaggedBookmarks(string tagName)
        {
            var bookmarks = await GetBookmarks();
            foreach (var bookmark in bookmarks)
            {
                bookmark.Tags.Add(new Tag() { Name = tagName });
            }
            return new ObservableCollection<IBookmark>(bookmarks);
        }

        public void AddBookmark(Bookmark newBookmark)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookmark(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<ITag>> GetTagsAsync()
        {
            return new ObservableCollection<ITag>(await GetTags());
        }

        public void RenameTag(string newTag, string oldTag)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(string tag)
        {
            throw new NotImplementedException();
        }

        // TASK<T> EXAMPLE
        async Task<DateTime> GetMiddayYesterday()
        {
            // The body of the method is expected to contain an awaited asynchronous 
            // call. 
            // Task.FromResult is a placeholder for actual work that returns a string. 
            var now = await Task.FromResult<DateTime>(new DateTime(DateTime.Now.AddDays(-1).Year, DateTime.Now.AddDays(-1).Month, DateTime.Now.AddDays(-1).Day, 12, 0, 0));
            
            return now;
        }

        private async Task<List<Tag>> GetTags()
        {
            var tags = await Task.FromResult<List<Tag>>(_tags);
            return tags;
        }

        private async Task<List<Bookmark>> GetBookmarks()
        {
            var bookmarks = await Task.FromResult(_bookmarks);
            return bookmarks;
        }
    }
}
