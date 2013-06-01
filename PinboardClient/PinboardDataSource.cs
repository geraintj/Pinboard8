using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PinboardApi.Model;
using RestSharp;

namespace PinboardApi
{
    public class PinboardDataSource : IPinboardApiWrapper
    {
        public async Task<DateTime> GetTimeOfLatestUpdateAsync()
        {
            var client = new RestClient("https://api.pinboard.in/");
            var request = new RestRequest("v1/posts/update?auth_token={id}", Method.GET);
            request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            //var response2 = client.Execute<DateTime>(request);
            IRestResponse response2 = await client.ExecuteTaskAsync(request);

            TextReader tr = new StringReader(response2.Content);
            XDocument doc = XDocument.Load(tr);
            var dateString = doc.Element("update").Attribute("time").Value;
            tr.Close();

            return DateTime.Parse(dateString);
        }

        public async Task<List<Bookmark>> GetAllBookmarksAsync()
        {
            var client = new RestClient("https://api.pinboard.in/");
            var request = new RestRequest("v1/posts/all?auth_token={id}", Method.GET);
            request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            var response = await client.ExecuteTaskAsync(request);

            var xdoc = XDocument.Parse(response.Content);
            var posts = xdoc.Root.Elements("post");
            return posts.Select(xElement => new Bookmark()
            {
                Url = xElement.Attribute("href").Value,
                Title = xElement.Attribute("description").Value,
                TagList = xElement.Attribute("tag").Value,
                Time = xElement.Attribute("time").Value,
            }).ToList();
        }

        public async Task<List<Bookmark>> GetBookmarksSinceAsync(DateTime date)
        {
            var client = new RestClient("https://api.pinboard.in/");
            var request = new RestRequest("v1/posts/recent?auth_token={id}", Method.GET);
            request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            var response = await client.ExecuteTaskAsync(request);

            var xdoc = XDocument.Parse(response.Content);
            var posts = xdoc.Root.Elements("post");
            return posts.Select(xElement => new Bookmark()
            {
                Url = xElement.Attribute("href").Value,
                Title = xElement.Attribute("description").Value,
                TagList = xElement.Attribute("tag").Value,
                Time = xElement.Attribute("time").Value,
            }).ToList();
        }

        public void AddBookmark(Bookmark newBookmark)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookmark(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            var client = new RestClient("https://api.pinboard.in/");
            var request = new RestRequest("v1/tags/get?auth_token={id}", Method.GET);
            request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            var response = await client.ExecuteTaskAsync(request);

            var xdoc = XDocument.Parse(response.Content);
            var tags = xdoc.Root.Elements("tag");
            return tags.Select(xElement => new Tag()
            {
                Name = xElement.Attribute("tag").Value,
                Count = int.Parse(xElement.Attribute("count").Value)
            }).ToList();
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
