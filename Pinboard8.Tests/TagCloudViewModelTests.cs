using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PinboardDomain.Repository;
using PinboardDomain.ViewModels;

namespace Pinboard8.Tests
{
    [TestClass]
    public class TagCloudViewModelTests
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
            var viewModel = new TagCloudViewModel(_repoStub);
            Assert.AreEqual(4, viewModel.Tags.Count);
        }
        
    }
}
