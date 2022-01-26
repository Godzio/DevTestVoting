using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnweloApi.DTOs;
using OnweloApi.Hubs;
using OnweloApi.Repositories;

namespace OnweloApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotingController : ControllerBase
    {
        private readonly ICandidatesRepository _candidatesRepository;
        private readonly IVotersRepository _votersRepository;
        public IHubContext<VotingHub, IVotingHub> _hubContext { get; }

        public VotingController(IHubContext<VotingHub, IVotingHub> hubContext,
            ICandidatesRepository candidatesRepository, IVotersRepository votersRepository)
        {
            _hubContext = hubContext;
            _candidatesRepository = candidatesRepository;
            _votersRepository = votersRepository;
        }

        [HttpPost]
        [Route("/submitVote")]
        public ActionResult SubmitVote(VoteDto vote)
        {
            var voter = _votersRepository.GetVoter(vote.VoterId);

            voter.CandidateId = vote.CandidateId;

            _votersRepository.SaveChanges();

            _hubContext.Clients.All.BroadcastAll(new CombinedDataDto
            {
                Candidates = _candidatesRepository.GetCandidates().Select(x => new CandidateDto(x)).ToList(),
                Voters = _votersRepository.GetVoters().Select(x => new VoterDto(x)).ToList()
            });
            return Ok();
        }
    }
}