using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PinboardDomain.Model;
using PinboardDomain.Repository;

namespace PinboardDomain.ViewModels
{
    public class TagPostsViewModel
    {
        private IPinboardApiWrapper _api;

        public Tag Tag { get; set; }

        public ObservableCollection<IBookmark> Bookmarks { get; set; }

        public TagPostsViewModel(IPinboardApiWrapper api, string value)
        {
            _api = api;
            this.Bookmarks = new ObservableCollection<IBookmark>();
            SetTag(new Tag() {Name = value});

        }

        public async void SetTag(Tag tag)
        {
            Tag = tag;
            var bookmarks = await _api.GetTaggedBookmarks(tag.Name);
            foreach (var bookmark in bookmarks)
            {
                Bookmarks.Add(bookmark);
            }
        }
    }
}
