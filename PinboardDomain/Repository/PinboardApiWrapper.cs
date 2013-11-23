using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using PinboardDomain.Model;

namespace PinboardDomain.Repository
{
    public class PinboardApiWrapper : IPinboardApiWrapper
    {

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

            return ParseBookmarks(responseString);
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
            var responseString = await MakeGetCall("posts/all", "&tag=" + tagName + "Z");

            return ParseBookmarks(responseString);
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
            var responseString = await MakeGetCall("tags/get");

            var tags = new ObservableCollection<ITag>();
            var xdoc = XDocument.Parse(responseString);
            foreach (var xElement in xdoc.Root.Elements("tag"))
            {
                tags.Add(new Tag() { Name = xElement.Attribute("tag").Value, Count = int.Parse(xElement.Attribute("count").Value) });
            }
            return tags;
        }

        public void RenameTag(string newTag, string oldTag)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(string tag)
        {
            throw new NotImplementedException();
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
                    Tags =
                        new List<Tag>()
                                {
                                    xElement.Attribute("tag")
                                            .Value.Split(new char[] {' '})
                                            .Select(s => new Tag() {Name = s})
                                            .FirstOrDefault()
                                }
                });
            }
            return bookmarks;
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
