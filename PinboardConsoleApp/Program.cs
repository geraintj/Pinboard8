﻿using System;
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
            //var task = WaitForGetAllBookmarks();
            var task = WaitForGetTags();
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
            var posts = await client.GetBookmarksSinceAsync(date);

            foreach (var bookmark in posts)
            {
                Console.WriteLine(bookmark.Title);
            }
        }

        static async Task WaitForGetAllBookmarks()
        {
            var client = new PinboardDataSource();
            var posts = await client.GetAllBookmarksAsync();

            foreach (var bookmark in posts)
            {
                Console.WriteLine(bookmark.Title);
            }
        }

        static async Task WaitForGetTags()
        {
            var client = new PinboardDataSource();
            var tags = await client.GetTagsAsync();

            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Name + "(" + tag.Count + ")");
            }
        }
    }
}
