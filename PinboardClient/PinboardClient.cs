using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Xml.Linq;
using System.IO;

namespace PinboardApi
{
    public class PinboardClient : IPinboardApiWrapper
    {
        public DateTime GetTimeOfLatestUpdate()
        {
            var client = new RestClient("https://api.pinboard.in/");
            var request = new RestRequest("v1/posts/update?auth_token={id}", Method.GET);
            request.AddUrlSegment("id", "geraintj:86AE2F150AE2D4027D38");
            var response2 = client.Execute<DateTime>(request);

            TextReader tr = new StringReader(response2.Content);
            XDocument doc = XDocument.Load(tr);
            var dateString = doc.Element("update").Attribute("time").Value;
            tr.Close();

            return DateTime.Parse(dateString);
        }

        public List<Model.Bookmark> GetAllBookmarks()
        {
            throw new NotImplementedException();
        }

        public List<Model.Bookmark> GetBookmarksSince(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void AddBookmark(Model.Bookmark newBookmark)
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
