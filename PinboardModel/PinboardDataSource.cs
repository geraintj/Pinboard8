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
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.pinboard.in/");

            var response =
                await client.GetAsync(String.Format("v1/posts/update?auth_token={0}", "geraintj:86AE2F150AE2D4027D38"));

            DateTime updateDate = DateTime.Now;
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                TextReader tr = new StringReader(responseString);
                XDocument doc = XDocument.Load(tr);
                var dateString = doc.Element("update").Attribute("time").Value;
                tr.Dispose();

                updateDate = DateTime.Parse(dateString);
            }

            return updateDate;
        }

        public async Task GetAllBookmarksAsync()
        {
            //var client = new RestClient("https://api.pinboard.in/");
            //var request = new RestRequest("v1/posts/all?auth_token={id}", Method.GET);
            //request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            //var response = await client.ExecuteTaskAsync(request);

            //var xdoc = XDocument.Parse(response.Content);
            //foreach (var xElement in xdoc.Root.Elements("post"))
            //{
            //    this.Bookmarks.Add(new Bookmark()
            //        {
            //            Url = xElement.Attribute("href").Value,
            //            Title = xElement.Attribute("description").Value,
            //            Time = xElement.Attribute("time").Value,
            //            Tags =
            //                new List<Tag>()
            //                    {
            //                        xElement.Attribute("tag")
            //                                .Value.Split(new char[] {' '})
            //                                .Select(s => new Tag() {Name = s})
            //                                .FirstOrDefault()
            //                    }
            //        });
            //}
            throw new NotImplementedException();
        }

        public async Task GetBookmarksSinceAsync(DateTime date)
        {
            //var client = new RestClient("https://api.pinboard.in/");
            //var request = new RestRequest("v1/posts/recent?auth_token={id}", Method.GET);
            //request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            //var response = await client.ExecuteTaskAsync(request);

            //var xdoc = XDocument.Parse(response.Content);
            //foreach (var xElement in xdoc.Root.Elements("post"))
            //{
            //    this.Bookmarks.Add(new Bookmark()
            //    {
            //        Url = xElement.Attribute("href").Value,
            //        Title = xElement.Attribute("description").Value,
            //        Time = xElement.Attribute("time").Value,
            //        Tags =
            //            new List<Tag>()
            //                    {
            //                        xElement.Attribute("tag")
            //                                .Value.Split(new char[] {' '})
            //                                .Select(s => new Tag() {Name = s})
            //                                .FirstOrDefault()
            //                    }
            //    });
            //}
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

        public async Task GetTagsAsync()
        {
            //var client = new RestClient("https://api.pinboard.in/");
            //var request = new RestRequest("v1/tags/get?auth_token={id}", Method.GET);
            //request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            //var response = await client.ExecuteTaskAsync(request);

            //var xdoc = XDocument.Parse(response.Content);
            //foreach (var xElement in xdoc.Root.Elements("tag"))
            //{
            //    Tags.Add(new Tag() { Name = xElement.Attribute("tag").Value, Count = int.Parse(xElement.Attribute("count").Value) });
            //}
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
    }
}
