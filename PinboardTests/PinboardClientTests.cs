using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinboardApi;

namespace PinboardTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PinboardClientTests
    {
       
       [TestMethod]
        public void LatestUpdateTimeReturnsDateTime()
        {
           var client = new PinboardClient();
           Assert.IsInstanceOfType(client.GetTimeOfLatestUpdate(), typeof(DateTime));
        }
    }
}
