using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PinboardApi;

namespace PinboardConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new PinboardClient();
            //Console.WriteLine(client.GetTimeOfLatestUpdate().ToString());
            var posts = client.GetBookmarksSince(new DateTime());
            foreach (var bookmark in posts)
            {
                Console.WriteLine(bookmark.Title);
            }
            
            Console.ReadLine();
        }
    }
}
