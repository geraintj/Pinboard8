using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PinboardDomain.Model;

namespace PinboardDomain.Repository
{
    public class PinboardApiWrapper : IPinboardApiWrapper
    {
        private List<Bookmark> _bookmarkCache;

        public PinboardApiWrapper()
        {
            GetAllBookmarksAsync();
        }

        public async Task<DateTime> GetTimeOfLatestUpdateAsync()
        {
            var responseString = await MakeGetCall("posts/update");

            TextReader tr = new StringReader(responseString);
            XDocument doc = XDocument.Load(tr);
            var dateString = doc.Element("update").Attribute("time").Value;
            tr.Dispose();

            return DateTime.Parse(dateString);
        }

        public async Task<ObservableCollection<IBookmark>> GetAllBookmarksAsync()
        {
            var responseString = await MakeGetCall("posts/all");

            var result = ParseBookmarks(responseString);
            _bookmarkCache = new List<Bookmark>((IEnumerable<Bookmark>)result);

            return result;
        }

        public List<Bookmark> GetAllBookmarks()
        {
            return _bookmarkCache;
        }

        public async Task<ObservableCollection<IBookmark>> GetBookmarksSinceAsync(DateTime date)
        {
            var dateString = String.Format("{0:s}", date);
            var responseString = await MakeGetCall("posts/all", "&fromdt=" + dateString + "Z");

            return ParseBookmarks(responseString);
        }

        public async Task<ObservableCollection<IBookmark>> GetRecentBookmarks()
        {
            var responseString = await MakeGetCall("posts/recent", "&count=20");

            return ParseBookmarks(responseString);
        }

        public async Task<ObservableCollection<IBookmark>> GetTaggedBookmarks(string tagName)
        {
            var responseString = await MakeGetCall("posts/recent", "&tag=" + tagName + "&count=100");

            return ParseBookmarks(responseString);
        }

        public async Task<Bookmark> GetBookmarkAsync(string url)
        {
            var responseString = await MakeGetCall("posts/get", "&url=" + url);
            return (Bookmark) ParseBookmarks(responseString).ToList().First();
        }

        public async void AddBookmark(Bookmark newBookmark)
        {
            var addBookmarkString = BuildBookmarkQueryString(newBookmark);
            await MakeGetCall("posts/add", addBookmarkString);
        }

        public async void DeleteBookmark(string url)
        {
            var response = await MakeGetCall("posts/delete", "url=" + url);
        }

        public async void UpdateBookmark(Bookmark editBookmark)
        {
            var editBookmarkString = BuildBookmarkQueryString(editBookmark);
            editBookmarkString += "&dt=";
            editBookmarkString += String.Format("{0:s}", editBookmark.Time);
            editBookmarkString += "Z";
            editBookmarkString += "&replace=yes";
            await MakeGetCall("posts/add", editBookmarkString);
        }

        public async Task<ObservableCollection<ITag>> GetTagsAsync()
        {
            var responseString = await MakeGetCall("tags/get");

            var tags = new ObservableCollection<ITag>();
            var xdoc = XDocument.Parse(responseString);
            foreach (var xElement in xdoc.Root.Elements("tag"))
            {
                tags.Add(new Tag() { Name = xElement.Attribute("tag").Value, Count = int.Parse(xElement.Attribute("count").Value) });
            }
            return tags;
        }

        public async void RenameTag(string newTag, string oldTag)
        {
            await MakeGetCall("tags/rename", String.Format("&old={0}&new={1}", oldTag, newTag));
        }

        public async void DeleteTag(string tag)
        {
            await MakeGetCall("tags/delete", "&tag=" + tag);
        }

        ObservableCollection<IBookmark> ParseBookmarks(string responseString)
        {
            var bookmarks = new ObservableCollection<IBookmark>();
            var xdoc = XDocument.Parse(responseString);
            foreach (var xElement in xdoc.Root.Elements("post"))
            {
                bookmarks.Add(new Bookmark()
                {
                    Url = xElement.Attribute("href").Value,
                    Title = xElement.Attribute("description").Value,
                    Time = xElement.Attribute("time").Value,
                    Tags = xElement.Attribute("tag")
                        .Value.Split(new char[] { ' ' })
                        .Select(s => new Tag() { Name = s }).ToList()
                });
            }
            return bookmarks;
        }

        string BuildBookmarkQueryString(Bookmark bookmark)
        {
            var bookmarkStringBuilder = new StringBuilder();
            bookmarkStringBuilder.Append("&url=");
            bookmarkStringBuilder.Append(bookmark.Url);
            bookmarkStringBuilder.Append("&description=");
            bookmarkStringBuilder.Append(bookmark.Title);
            if (bookmark.Tags.Any())
            {
                bookmarkStringBuilder.Append("&tags=");
                foreach (var tag in bookmark.Tags)
                {
                    bookmarkStringBuilder.Append(tag.Name + ",");
                }
                bookmarkStringBuilder.Remove(bookmarkStringBuilder.Length - 1, 1);
            }
            return bookmarkStringBuilder.ToString();
        }

        async Task<string> MakeGetCall(string urlPart, string queryString =  "")
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.pinboard.in/");

            var response =
                await client.GetAsync(String.Format("v1/" + urlPart + "?auth_token={0}{1}", "geraintj:86AE2F150AE2D4027D38", queryString));


            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return response.StatusCode.ToString();
        }

    }
}
