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
        
    }
}
