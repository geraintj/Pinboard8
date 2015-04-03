using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PinboardDomain.Repository;
using PinboardDomain.ViewModels;

namespace Pinboard8.Tests
{
    [TestClass]
    public class AllPostsViewModelTests
    {
        private IPinboardApiWrapper _repoStub;

        [TestInitialize]
        public void Initialize()
        {
            _repoStub = new MockPinboardApiWrapper();
        }

        
        [TestMethod]
        public async Task  GetLatestDateTest()
        {
            var viewModel = new AllPostsViewModel(_repoStub);

            var middayYesterday = new DateTime(DateTime.Now.AddDays(-1).Year, DateTime.Now.AddDays(-1).Month,
                                               DateTime.Now.AddDays(-1).Day, 12, 0, 0);

            Assert.AreEqual(middayYesterday, await viewModel.GetLastUpdate());
        }
        
    }
}
