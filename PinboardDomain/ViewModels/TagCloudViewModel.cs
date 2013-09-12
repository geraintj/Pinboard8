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
        private ObservableCollection<Tag> _tags;
        private IPinboardApiWrapper _api;

        public TagCloudViewModel(IPinboardApiWrapper api)
        {
            _api = api;
        }
    }
}
