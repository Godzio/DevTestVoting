using System.Dynamic;
using System.Security.Cryptography;

namespace OnweloApi.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? CandidateId { get; set; }
        public Candidate CandidateVotedOn { get; set; }
    }
}