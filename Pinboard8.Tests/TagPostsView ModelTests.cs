using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PinboardDomain.Model;
using PinboardDomain.Repository;
using PinboardDomain.ViewModels;

namespace Pinboard8.Tests
{
    [TestClass]
    public class TagPostsViewModelTests
    {
        private IPinboardApiWrapper _repoStub;

        [TestInitialize]
        public void Initialize()
        {
            _repoStub = new MockPinboardApiWrapper();
        }

        [TestMethod]
        public void TagNameTest()
        {
            var viewModel = new TagPostsViewModel(_repoStub);
            viewModel.SetTag(new Tag() { Name = "tag"});

            Assert.AreEqual("tag", viewModel.Tag.Name);
        }

        [TestMethod]
        public void BookmarksReturnedTest()
        {
            var viewModel = new TagPostsViewModel(_repoStub);
            viewModel.SetTag(new Tag() { Name = "tag" });

            Assert.AreEqual("tag", viewModel.Bookmarks[0].Tags[0].Name);
        }
    }
}
