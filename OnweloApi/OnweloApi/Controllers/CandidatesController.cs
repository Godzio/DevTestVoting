using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnweloApi.DTOs;
using OnweloApi.Hubs;
using OnweloApi.Models;
using OnweloApi.Repositories;

namespace OnweloApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        public IHubContext<VotingHub, IVotingHub> _hubContext { get; }
        private readonly ICandidatesRepository _candidatesRepository;

        public CandidatesController(IHubContext<VotingHub, IVotingHub> hubContext, ICandidatesRepository candidatesRepository)
        {
            _hubContext = hubContext;
            _candidatesRepository = candidatesRepository;
        }
        
        [HttpPost]
        [Route("/addCandidate")]
        public ActionResult AddCandidate(CandidateDto candidate)
        {
            var newCandidate = new Candidate {Name = candidate.Name};
            var candidates = _candidatesRepository.AddCandidate(newCandidate);

            _hubContext.Clients.All.BroadcastCandidates(candidates.Select(x=> new CandidateDto(x)).ToList());
            return Ok();
        }
    }
}