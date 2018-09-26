using System.Collections.Generic;

namespace JobAdder.Web.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; } 
        public List<Candidate> Candidates { get; set; }
    }
}