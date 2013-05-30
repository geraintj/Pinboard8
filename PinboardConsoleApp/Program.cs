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
            Console.WriteLine(client.GetBookmarksSince(new DateTime()));
            Console.ReadLine();
        }
    }
}
