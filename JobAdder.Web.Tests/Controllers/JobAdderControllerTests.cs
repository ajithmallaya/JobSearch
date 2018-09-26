using System.Net.Http;
using NUnit.Framework;
using JobAdder.Web.Controllers;
using JobAdder.Web.Helper;
using JobAdder.Web.Manager;
using JobAdder.Web.Services;

namespace JobAdder.Web.Tests.Controllers
{
    [TestFixture]
    class JobAdderControllerTests
    {
        private ISearchManager _searchManager;
        private IApiHelper _apiHelper;
        private HomeController _homeController;
        [SetUp]
        public void SetUp()
        {
            _apiHelper = new ApiHelper(new HttpClient());
            _searchManager = new SearchManager(new SearchService(_apiHelper));
            _homeController = new HomeController(_searchManager);
        }

        [TestCase("Mobile Developer", "iOS",1)]
        [TestCase("Head Chef", "cooking",2)]
         public void GetJobsAndCandidates(string roles, string searchKey,int result)
        {
            var response = _homeController.GetJobsAndCandidates(roles, searchKey);
            Assert.NotNull(response.Data);
        }

    }
}
