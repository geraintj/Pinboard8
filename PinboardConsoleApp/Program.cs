using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinboardDomain;
using PinboardDomain.Repository;

namespace PinboardConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //var task = WaitForGetTimeOfLatestUpdate();
            //var task = WaitForGetAllBookmarks();
            //var task = WaitForGetTags();
            //var task = WaitForGetBookmarksSince(new DateTime(2013,9,1,0,0,0));
            var task = WaitForGetRecentBookmarks();
            task.Wait();

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

        static async Task WaitForGetAllBookmarks()
        {
            var client = new PinboardApiWrapper();
            var bookmarks = await client.GetAllBookmarksAsync();

            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
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
    }
}
