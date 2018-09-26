using System.Collections.Generic;
using System.Linq;
using JobAdder.Web.Models;

namespace JobAdder.Web.Extensions
{
    public static class Jobs
    {
        public static List<Job> Filter(this IEnumerable<Job> jobs, string roles, string skills,IEnumerable<Candidate> candidates)
        {
            var filteredJobs = new List<Job>();
            foreach (var job in jobs.ToList())
            {
                var skillTags = job.Skills.Split(',');
                if (job.Name.ToLower().Contains(roles.ToLower()) || skillTags.Any( x => x.Trim().ToLower().Contains(skills.ToLower())))
                {
                    job.Candidates = candidates?.Where(x => x.Skills.Any(y => y.Trim().ToLower().Contains(skills.ToLower()))).ToList();
                    filteredJobs.Add(job);
                }
            }
            return filteredJobs;
        }
    }
}