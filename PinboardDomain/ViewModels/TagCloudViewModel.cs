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
    public class TagCloudViewModel
    {
        private IPinboardApiWrapper _api;

        public TagCloudViewModel(IPinboardApiWrapper api)
        {
            _api = api;
            this.Tags = new ObservableCollection<ITag>();
            Initialise(null);
        }

        public ObservableCollection<ITag> Tags { get; set; }

        public async void Initialise(object parameter)
        {
            var tags = await _api.GetTagsAsync();
            foreach (var tag in tags)
            {
                this.Tags.Add(tag);
            }
        }
    }
}
