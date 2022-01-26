using System.Linq;
using OnweloApi.Models;

namespace OnweloApi.DTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VotesCount { get; set; }

        public CandidateDto()
        {
            
        }

        public CandidateDto(Candidate candidate)
        {
            Id = candidate.Id;
            Name = candidate.Name;
            VotesCount = candidate.Voters?.ToList().Count ?? 0;
        }
    }
}
