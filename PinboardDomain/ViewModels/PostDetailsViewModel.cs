using System.Collections.Generic;
using PinboardDomain.Model;
using PinboardDomain.Repository;

namespace PinboardDomain.ViewModels
{
    public class PostDetailsViewModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public List<Tag> Tags { get; set; }
        public List<ITag> AllTags { get; set; }
    }
}
