using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PinboardDomain.Repository;

namespace Pinboard8.Tests
{
    [TestClass]
    public class TagCloudViewModelTests
    {
        private IPinboardApiWrapper _repoStub;

        [TestInitialize]
        public void Initialize()
        {
            _repoStub = new PinboardApiWrapper();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
