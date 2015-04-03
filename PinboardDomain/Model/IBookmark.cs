using System.Collections.Generic;

namespace PinboardDomain.Model
{
    public interface IBookmark
    {
        string Url { get; set; }
        string Title { get; set; }
        string Time { get; set; }
        List<Tag> Tags { get; set; }
    }
}