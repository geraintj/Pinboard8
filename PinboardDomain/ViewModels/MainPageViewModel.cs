using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinboardDomain.Model;
using PinboardDomain.Repository;

namespace PinboardDomain.ViewModels
{
    public class MainPageViewModel
    {
        private IPinboardApiWrapper _api;

        public ObservableCollection<ITag> Tags { get; set; }

        public ObservableCollection<IBookmark> RecentBookmarks { get; set; }

        public MainPageViewModel(IPinboardApiWrapper api)
        {
            _api = api;
            this.Tags = new ObservableCollection<ITag>();
            this.RecentBookmarks = new ObservableCollection<IBookmark>();
            Initialise(null);
        }

        private async void Initialise(object parameter)
        {
            var tags = await _api.GetTagsAsync();
            foreach (var tag in tags)
            {
                this.Tags.Add(tag);
            }

            var bookmarks = await _api.GetRecentBookmarks();
            foreach (var bookmark in bookmarks)
            {
                this.RecentBookmarks.Add(bookmark);
            }
        }
    }
}
