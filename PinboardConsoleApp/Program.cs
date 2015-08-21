using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PinboardDomain;
using PinboardDomain.Model;
using PinboardDomain.Repository;

namespace PinboardConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //var task = WaitForGetTimeOfLatestUpdate();
            //GetAllBookmarks();
            //var task = WaitForGetTags();
            //var task = WaitForGetBookmarksSince(new DateTime(2013,9,1,0,0,0));
            //var task = WaitForGetRecentBookmarks();
            //AddBookmark();
            //DeleteBookmark();
            //var task = WaitForTagBookmarks();
            var task = EditBookmark();
            //task.Wait();

            Console.ReadLine();
        }

        static async Task WaitForGetTimeOfLatestUpdate()
        {
            var client = new PinboardApiWrapper();
            var result = await client.GetTimeOfLatestUpdateAsync();
            Console.WriteLine(result.ToString());
        }

        static async Task WaitForGetBookmarksSince(DateTime date)
        {
            var client = new PinboardApiWrapper();
            var bookmarks = await client.GetBookmarksSinceAsync(date);

            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
        }

        static void GetAllBookmarks()
        {
            var client = new PinboardApiWrapper();
            var bookmarks = client.GetAllBookmarks();

            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
        }

        static void AddBookmark()
        {
            var client = new PinboardApiWrapper();

            var bookmark = new Bookmark()
            {
                Url =
                    "http://www.winbeta.org/news/windows-10-by-10-series-for-developers-continues-with-live-tiles-and-notifications",
                Title = "Live Tiles and Notififcations",
                Tags = new List<Tag>() {new Tag() {Name = "store"}}
            };
            client.AddBookmark(bookmark);
        }

        static void DeleteBookmark()
        {
            var client = new PinboardApiWrapper();
            client.DeleteBookmark("http://www.winbeta.org/news/windows-10-by-10-series-for-developers-continues-with-live-tiles-and-notifications");
        }

        static async Task WaitForGetTags()
        {
            var client = new PinboardApiWrapper();
            var tags = await client.GetTagsAsync();

            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Name + "(" + tag.Count + ")");
            }
        }

        static async Task WaitForGetRecentBookmarks()
        {
            var client = new PinboardApiWrapper();
            var bookmarks = await client.GetRecentBookmarks();

            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
        }

        static async Task WaitForTagBookmarks()
        {
            var client = new PinboardApiWrapper();
            var bookmarks = await client.GetTaggedBookmarks("recipes");

            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
        }
        
        static async Task GetSingleBookmark()
        {
            var client = new PinboardApiWrapper();
            var bookmark =
                await
                    client.GetBookmarkAsync(
                        "http://www.winbeta.org/news/windows-10-by-10-series-for-developers-continues-with-live-tiles-and-notifications");

            if (bookmark!= null)
                Console.WriteLine(bookmark.Title);
        }

        static async Task EditBookmark()
        {
            var client = new PinboardApiWrapper();
            var bookmark =
                await
                    client.GetBookmarkAsync(
                        "http://www.winbeta.org/news/windows-10-by-10-series-for-developers-continues-with-live-tiles-and-notifications");
            bookmark.Tags.Add(new Tag() { Name = "universal"});

            client.UpdateBookmark(bookmark);
        }
    }
}
