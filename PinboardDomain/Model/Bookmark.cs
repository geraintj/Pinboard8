using System.Collections.Generic;

namespace PinboardDomain.Model
{
    public class Bookmark : IBookmark
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
