using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnweloApi.Models;
using OnweloApi.OnweloApiDbContext;

namespace OnweloApi.Repositories
{
    public class CandidatesRepository : ICandidatesRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Candidate> GetCandidates()
        {
            return _context.Candidates.Include(c => c.Voters).ToList();
        }

        public List<Candidate> AddCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            return _context.Candidates.Include(c => c.Voters).ToList();
        }
    }
}