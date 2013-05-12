using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PinboardClient.Model;

namespace PinboardClient
{
    interface IPinboardApiWrapper
    {
        List<Tag> GetTags();
        List<Bookmark> GetBookmarks(string tag);
        List<Bookmark> GetAllBookmarks();
    }
}
