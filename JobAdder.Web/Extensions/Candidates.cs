using System.Collections.Generic;
using System.Linq;
using JobAdder.Web.Models;

namespace JobAdder.Web.Extensions
{
    public static class Candidates
    {
        public static List<Candidate> Filter(this IEnumerable<Candidate> candidates,string skills)
        {
            var filteredCandidates = new List<Candidate>();
            foreach (var can in candidates.ToList())
            {
                var skillTags = can.SkillTags.Split(',');
                if (skillTags.Any(x => x.Trim().ToLower().Contains(skills.ToLower())))
                {
                    can.Skills = skillTags.ToList();
                    filteredCandidates.Add(can);
                }
            }
            return filteredCandidates;
        }
    }
}