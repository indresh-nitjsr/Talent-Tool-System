using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TalentToolSystem.Services.CandidateAPI.Data;
using TalentToolSystem.Services.CandidateAPI.Model;
using TalentToolSystem.Services.CandidateAPI.Services;

namespace TalentToolSystem.Services.CandidateAPI.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly CandidateContext _dbContext;

        public CandidateService(CandidateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateCandidate(Candidate candidate)
        {
            string skillsetParameter = string.Join(",", candidate.SkillSet);


            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@CandidateName", candidate.CandidateName),
                new SqlParameter("@Email", candidate.Email),
                new SqlParameter("@Mobile", candidate.Mobile),
                new SqlParameter("@CurrentCompany", candidate.CurrentCompany),
                new SqlParameter("@SkillSet", skillsetParameter),
                new SqlParameter("@YearOfExperience", candidate.YearOfExperience),
                new SqlParameter("@Location", candidate.Location),
                new SqlParameter("@CTC", candidate.CTC),
                new SqlParameter("@ECTC", candidate.ECTC),
                new SqlParameter("@NoticePeriod", candidate.NoticePeriod),
                new SqlParameter("@EmployeeID", candidate.EmployeeID),
                new SqlParameter("@Status", candidate.Status),
            };


            var parameterNames = string.Join(",", parameters.Select(p => p.ParameterName));

            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                $"exec AddNewCandidate {parameterNames}",
                parameters.ToArray()
            );
            

            return result;
        }




        public async Task<int> DeleteCandidate(int CandidateId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteCandidate {CandidateId}"));
        }





        public async Task<List<Candidate>> GetAllCandidate()
        {
            return await _dbContext.Candidates
                .FromSqlRaw<Candidate>("GetAllCandidates")
                .ToListAsync();
        }






        public async Task<IEnumerable<Candidate>> GetCandidateById(int CandidateId)
        {
            var param = new SqlParameter("@CandidateId", CandidateId);

            var candidateDetails = await Task.Run(() => _dbContext.Candidates
                .FromSqlRaw<Candidate>(@"exec GetParticularCandidate @CandidateId", param)
                .ToListAsync());

            return candidateDetails;
        }





        public async Task<int> UpdateCandidate(Candidate candidate)
        {

            string skillsetParameter = string.Join(",", candidate.SkillSet);

            var parameters = new List<SqlParameter>
            {

                new SqlParameter("@CandidateId", candidate.CandidateId),
                new SqlParameter("@CandidateName", candidate.CandidateName),
                new SqlParameter("@Email", candidate.Email),
                new SqlParameter("@Mobile", candidate.Mobile),
                new SqlParameter("@CurrentCompany", candidate.CurrentCompany),
                new SqlParameter("@SkillSet", skillsetParameter),
                new SqlParameter("@YearOfExperience", candidate.YearOfExperience),
                new SqlParameter("@Location", candidate.Location),
                new SqlParameter("@CTC", candidate.CTC),
                new SqlParameter("@ECTC", candidate.ECTC),
                new SqlParameter("@NoticePeriod", candidate.NoticePeriod),
                new SqlParameter("@EmployeeID", candidate.EmployeeID),
                new SqlParameter("@Status", candidate.Status),

            };

            var parameterNames = string.Join(",", parameters.Select(p => p.ParameterName));

            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                $"exec UpdateCandidate {parameterNames}",
                parameters.ToArray()
              );
            

            return result;
        }
    } 
}