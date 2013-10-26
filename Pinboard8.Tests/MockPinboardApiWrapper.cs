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
        public async Task<DateTime> GetTimeOfLatestUpdateAsync()
        {
            return await GetMiddayYesterday();
        }

        public async Task<ObservableCollection<Bookmark>> GetAllBookmarksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Bookmark>> GetBookmarksSinceAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void AddBookmark(Bookmark newBookmark)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookmark(string url)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<ITag>> GetTagsAsync()
        {
            throw new NotImplementedException();
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
    }
}
