using OnweloApi.Models;

namespace OnweloApi.DTOs
{
    public class VoterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }

        public VoterDto()
        {
                
        }

        public VoterDto(Voter voter)
        {
            Id = voter.Id;
            Name = voter.Name;
            HasVoted = voter.CandidateId.HasValue;
        }
    }
}
