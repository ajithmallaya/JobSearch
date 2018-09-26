using System.Web.Mvc;
using JobAdder.Web.Manager;

namespace JobAdder.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchManager _searchManager;

        public HomeController()
        {
            _searchManager = new SearchManager();
        }

        public HomeController(ISearchManager searchManager = null)
        {
            _searchManager = searchManager ?? new SearchManager();
        }

        [HttpGet]
        [Route("Jobs/{roles}/{searchKey}")]
        public JsonResult GetJobsAndCandidates(string roles, string searchKey)
        {
            var data = _searchManager.GetJobsAndCandidates(roles, searchKey);
            return Json(new { result = data}, JsonRequestBehavior.AllowGet );
        }

    }
}