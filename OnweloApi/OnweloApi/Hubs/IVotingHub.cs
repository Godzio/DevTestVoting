using System.Collections.Generic;
using System.Threading.Tasks;
using OnweloApi.DTOs;

namespace OnweloApi.Hubs
{
    public interface IVotingHub
    {
        Task BroadcastAll(CombinedDataDto combinedDataDto);
        Task BroadcastCandidates(List<CandidateDto> candidates);
        Task BroadcastVoters(List<VoterDto> voters);
    }
}