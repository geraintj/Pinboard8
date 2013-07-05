using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using PinboardApi.Model;
using System.Xml.Serialization;

namespace PinboardApi
{
    public class PinboardClient
    {
        public async Task<DateTime> GetTimeOfLatestUpdate()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.pinboard.in/");

            var response =
                await client.GetAsync(String.Format("v1/posts/update?auth_token={0}", "geraintj:86AE2F150AE2D4027D38"));

            DateTime updateDate;
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

        public async Task<DateTime> GetTimeOfLatestUpdateAsync()
        {
            //var client = new RestClient("https://api.pinboard.in/");
            //var request = new RestRequest("v1/posts/update?auth_token={id}", Method.GET);
            //request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            ////var response2 = client.Execute<DateTime>(request);
            //IRestResponse response2 = await client.ExecuteTaskAsync(request);

            //TextReader tr = new StringReader(response2.Content);
            //XDocument doc = XDocument.Load(tr);
            //var dateString = doc.Element("update").Attribute("time").Value;
            //tr.Close();

            //return DateTime.Parse(dateString);
            throw new NotImplementedException();
        }

        public List<Bookmark> GetAllBookmarks()
        {
            //var client = new RestClient("https://api.pinboard.in/");
            //var request = new RestRequest("v1/posts/all?auth_token={id}", Method.GET);
            //request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            //var response = client.Execute(request);


            //var xdoc = XDocument.Parse(response.Content);
            //var posts = xdoc.Root.Elements("post");
            //return posts.Select(xElement => new Bookmark()
            //{
            //    Url = xElement.Attribute("href").Value,
            //    Title = xElement.Attribute("description").Value,
            //    Time = xElement.Attribute("time").Value,
            //    Tags = new List<Tag>() { xElement.Attribute("tag").Value.Split(new char[] { ' ' }).Select(s => new Tag() { Name = s }).Single() }
            //}).ToList();
            throw new NotImplementedException();
        }

        public List<Bookmark> GetBookmarksSince(DateTime date)
        {
            //var client = new RestClient("https://api.pinboard.in/");
            //var request = new RestRequest("v1/posts/recent?auth_token={id}", Method.GET);
            //request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            //var response = client.Execute(request);

            //var xdoc = XDocument.Parse(response.Content);
            //var posts = xdoc.Root.Elements("post");
            //return posts.Select(xElement => new Bookmark()
            //    {
            //        Url = xElement.Attribute("href").Value, 
            //        Title = xElement.Attribute("description").Value,                     
            //        Tags = new List<Tag>() {xElement.Attribute("tag").Value.Split(new char[] {' '}).Select(s => new Tag() {Name = s}).Single()},
            //        Time = xElement.Attribute("time").Value,
            //    }).ToList();
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

        public List<Model.Tag> GetTags()
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

    }
}
