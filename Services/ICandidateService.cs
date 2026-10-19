using MyPortfolio.Model;
using MyPortfolio.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services
{
    public interface ICandidateService
    {
        Task<Candidate> GetCandidateProfileById(Guid userId);
        Task<StatusDTO> AddCandidateProfile(Candidate candidate);
        Task<StatusDTO> UpdateCandidateProfile(Candidate candidate);
        Task<StatusDTO> DeleteCandidateProfile(Guid userId);
    }
}
