using System;
using System.Collections.Generic;
using System.Net.Http;
using JobAdder.Web.Exceptions;
using JobAdder.Web.Helper;
using JobAdder.Web.Models;

namespace JobAdder.Web.Services
{
    public interface ISearchService
    {
         List<Job> GetJobs();
        List<Candidate> GetCandidates();
    }
    public class SearchService : ISearchService
    {
        private readonly IApiHelper _apiHelper;
        public SearchService(IApiHelper apiHelper = null)
        {
            _apiHelper = apiHelper ?? new ApiHelper();
        }
        public List<Job>  GetJobs()
        {
            try
            {
                var response = _apiHelper.ExecuteApiCallAsync("jobs");

                var jobs = response.Content.ReadAsAsync<List<Job>>().Result;

                return jobs;
            }
            catch (Exception ex)
            {
                throw new  JobAdderException(true, "GetJobsAsync",ex);
            }
        }

        public List<Candidate> GetCandidates()
        {
            try
            {
                var response = _apiHelper.ExecuteApiCallAsync("candidates");

                var canidates = response.Content.ReadAsAsync<List<Candidate>>().Result;

                return canidates;
            }
            catch (Exception ex)
            {
                throw new JobAdderException(true, "GetCandidatesAsync", ex);
            }
        }
    }
}