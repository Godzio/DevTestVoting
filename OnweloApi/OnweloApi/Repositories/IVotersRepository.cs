using System.Collections.Generic;
using OnweloApi.Models;

namespace OnweloApi.Repositories
{
    public interface IVotersRepository
    {
        List<Voter> GetVoters();
        void SaveChanges();
        Voter GetVoter(int voterId);
        List<Voter> AddVoter(Voter voter);
    }
}