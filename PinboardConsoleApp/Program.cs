using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinboardApi;

namespace PinboardConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //var task = WaitForGetTimeOfLatestUpdate();
           // var task = WaitForGetAllBookmarks();
            //var task = WaitForGetTags();
            var task = WaitForGetBookmarksSince(new DateTime(2013,7,3,0,0,0));
            task.Wait();

            Console.ReadLine();
        }

        static async Task WaitForGetTimeOfLatestUpdate()
        {
            var client = new PinboardDataSource();
            var result = await client.GetTimeOfLatestUpdateAsync();
            Console.WriteLine(result.ToString());
        }

        static async Task WaitForGetBookmarksSince(DateTime date)
        {
            var client = new PinboardDataSource();
            await client.GetBookmarksSinceAsync(date);

            foreach (var bookmark in client.Bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
        }

        static async Task WaitForGetAllBookmarks()
        {
            var client = new PinboardDataSource();
            await client.GetAllBookmarksAsync();

            foreach (var bookmark in client.Bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
        }

        static async Task WaitForGetTags()
        {
            var client = new PinboardDataSource();
            await client.GetTagsAsync();

            foreach (var tag in client.Tags)
            {
                Console.WriteLine(tag.Name + "(" + tag.Count + ")");
            }
        }
    }
}
