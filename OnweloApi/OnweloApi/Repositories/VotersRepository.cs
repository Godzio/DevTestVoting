using System.Collections.Generic;
using System.Linq;
using OnweloApi.Models;
using OnweloApi.OnweloApiDbContext;

namespace OnweloApi.Repositories
{
    public class VotersRepository : IVotersRepository
    {
        private readonly ApplicationDbContext _context;

        public VotersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Voter> GetVoters()
        {
            return _context.Voters.ToList();
        }

        public Voter GetVoter(int voterId)
        {
            return _context.Voters.First(x => x.Id == voterId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Voter> AddVoter(Voter voter)
        {
            _context.Voters.Add(voter);
            _context.SaveChanges();

            return _context.Voters.ToList();
        }
    }
}
