using System.Collections.Generic;

namespace OnweloApi.DTOs
{
    public class CombinedDataDto
    {
        public List<VoterDto> Voters { get; set; }
        public List<CandidateDto> Candidates { get; set; }
    }
}