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
    public class VotersController : ControllerBase
    {
        private readonly IVotersRepository _votersRepository;
        public IHubContext<VotingHub, IVotingHub> _hubContext { get; }

        public VotersController(IHubContext<VotingHub, IVotingHub> hubContext, IVotersRepository votersRepository)
        {
            _hubContext = hubContext;
            _votersRepository = votersRepository;
        }

        [HttpPost]
        [Route("/addVoter")]
        public ActionResult AddVoter(VoterDto voter)
        {
            var newVoter = new Voter {Name = voter.Name};
            var voters = _votersRepository.AddVoter(newVoter);

            _hubContext.Clients.All.BroadcastVoters(voters.Select(x => new VoterDto(x)).ToList());
            return Ok();
        }
    }
}