using System;
using System.Linq;
using JobAdder.Web.Extensions;
using JobAdder.Web.Models;
using JobAdder.Web.Services;

namespace JobAdder.Web.Manager
{
    public interface ISearchManager
    {
        SearchResults GetJobsAndCandidates(string roles, string searchKey);
        GetRolesResponse GetRoles();
    }

    public class SearchManager : ISearchManager
    {
        private readonly ISearchService _searchService;

        public SearchManager(ISearchService searchService = null)
        {
            _searchService = searchService ?? new SearchService();
        }

        public SearchResults GetJobsAndCandidates(string roles, string searchKey)
        {
            var matchingJobs = _searchService.GetJobs();
            var candidates = _searchService.GetCandidates().Filter(searchKey).ToList().Take(5);
            matchingJobs = matchingJobs.Filter(roles, searchKey, candidates);

            return new SearchResults()
            {
                JobWithCandidates = matchingJobs
            };
        }

        public GetRolesResponse GetRoles()
        {
            throw new NotImplementedException();
        }
    }
}