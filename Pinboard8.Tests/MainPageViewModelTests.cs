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
    public class MainPageViewModelTests
    {
        private IPinboardApiWrapper _repoStub;

        [TestInitialize]
        public void Initialize()
        {
            _repoStub = new MockPinboardApiWrapper();
        }

        [TestMethod]
        public void TagsCollectionTest()
        {
            var viewModel = new MainPageViewModel(_repoStub);
            Assert.AreEqual(4, viewModel.Tags.Count);
        }

        [TestMethod]
        public void RecentBookmarkCollectionTest()
        {
            var viewModel= new MainPageViewModel(_repoStub);
            Assert.AreEqual(3, viewModel.RecentBookmarks.Count);
        }
    }
}
