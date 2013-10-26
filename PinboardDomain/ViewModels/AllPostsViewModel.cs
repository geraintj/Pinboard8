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
    public class AllPostsViewModel
    {
        private IPinboardApiWrapper _api;

        public AllPostsViewModel(IPinboardApiWrapper api)
        {
            _api = api;
        }

        public ObservableCollection<IBookmark> Bookmarks { get; set; }

        public async Task<DateTime> GetLastUpdate()
        {
            return await _api.GetTimeOfLatestUpdateAsync();
        }
    }
}
