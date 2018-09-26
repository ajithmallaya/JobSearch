using System.Collections.Generic;

namespace JobAdder.Web.Models
{
    public class Candidate
    {
        public string Name { get; set; }
        public string SkillTags { get; set; }
        public List<string> Skills { get; set; }
    }

}