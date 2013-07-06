using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PinboardApi.Model;
using RestSharp;

namespace PinboardApi
{
    public class PinboardDataSource : IPinboardApiWrapper
    {
        private readonly ObservableCollection<Bookmark> _bookmarks = new ObservableCollection<Bookmark>();
        private readonly ObservableCollection<Tag> _tags = new ObservableCollection<Tag>();

        public ObservableCollection<Bookmark> Bookmarks
        {
            get { return _bookmarks; }
        }

        public ObservableCollection<Tag> Tags
        {
            get { return _tags; }
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

        public async Task GetAllBookmarksAsync()
        {
            var responseString = await MakeGetCall("posts/all");

            var xdoc = XDocument.Parse(responseString);
            foreach (var xElement in xdoc.Root.Elements("post"))
            {
                this.Bookmarks.Add(new Bookmark()
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
        }

        public async Task GetBookmarksSinceAsync(DateTime date)
        {
            var responseString = await MakeGetCall("posts/recent");

            var xdoc = XDocument.Parse(responseString);
            foreach (var xElement in xdoc.Root.Elements("post"))
            {
                this.Bookmarks.Add(new Bookmark()
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
        }

        public void AddBookmark(Bookmark newBookmark)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookmark(string url)
        {
            throw new NotImplementedException();
        }

        public async Task GetTagsAsync()
        {
            var responseString = await MakeGetCall("tags/get");

            var xdoc = XDocument.Parse(responseString);
            foreach (var xElement in xdoc.Root.Elements("tag"))
            {
                Tags.Add(new Tag() { Name = xElement.Attribute("tag").Value, Count = int.Parse(xElement.Attribute("count").Value) });
            }
        }

        public void RenameTag(string newTag, string oldTag)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(string tag)
        {
            throw new NotImplementedException();
        }

        async Task<string> MakeGetCall(string urlPart)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.pinboard.in/");

            var response =
                await client.GetAsync(String.Format("v1/" + urlPart + "?auth_token={0}", "geraintj:86AE2F150AE2D4027D38"));


            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return response.StatusCode.ToString();
        }
    }
}
