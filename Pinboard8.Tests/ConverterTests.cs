using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Pinboard8.Converters;


namespace Pinboard8.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void DateConverterTest()
        {
            var dateString = "2013-10-05T10:43:30Z";

            var converter = new DateElapsedTimeConverter();
            Assert.IsInstanceOfType(converter.Convert(dateString, null, null, null), typeof(string));

        }
    }
}
