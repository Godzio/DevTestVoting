using System.Collections.Generic;
using OnweloApi.Models;

namespace OnweloApi.Repositories
{
    public interface ICandidatesRepository
    {
        List<Candidate> GetCandidates();
        List<Candidate> AddCandidate(Candidate candidate);
    }
}