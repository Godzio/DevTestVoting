using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using OnweloApi.DTOs;
using OnweloApi.Repositories;

namespace OnweloApi.Hubs
{
    public class VotingHub : Hub<IVotingHub>
    {
        private readonly IVotersRepository _votersRepository;
        private readonly ICandidatesRepository _candidatesRepository;
        public VotingHub(IVotersRepository votersRepository, ICandidatesRepository candidatesRepository)
        {
            _votersRepository = votersRepository;
            _candidatesRepository = candidatesRepository;
        }

        public override Task OnConnectedAsync()
        {
            var data = new CombinedDataDto
            {
                Voters =  _votersRepository.GetVoters().Select(x => new VoterDto(x)).ToList(),
                Candidates = _candidatesRepository.GetCandidates().Select(x => new CandidateDto(x)).ToList()
            };

            Clients.Caller.BroadcastAll(data);
            return base.OnConnectedAsync();
        }
    }
}