using System.Collections.Generic;

namespace OnweloApi.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Voter> Voters { get; set; }
    }
}