using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TalentToolSystem.Services.DemandAPI.Data;
using TalentToolSystem.Services.DemandAPI.Model;

namespace TalentToolSystem.Services.DemandAPI.Service
{
    public class DemandService : IDemandService
    {
        private readonly DemandContext _dbContext;

        public DemandService(DemandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateDemand(Demand demand)
        {
            string skillsParameter = string.Join(",", demand.Skills);
            var parameters = new List<SqlParameter>
           {
                 new SqlParameter("@DemandName", demand.DemandName),
                 new SqlParameter("@Email", demand.Email),
                 new SqlParameter("@Manager", demand.Manager),
                 new SqlParameter("@OpenPosition", demand.OpenPosition),
                 new SqlParameter("@Experience", demand.Experience),
                 new SqlParameter("@MaxBudget", demand.MaxBudget),
                 new SqlParameter("@NoticePeriod", demand.NoticePeriod),
                 new SqlParameter("@EmployeeType", demand.EmployeeType),
                 new SqlParameter("@Status", demand.Status),
                 new SqlParameter("@SkillName", skillsParameter),
                 new SqlParameter("@Location", demand.Location),
                 new SqlParameter("@AccountName", demand.Account_Name),
           };

            var parameterNames = string.Join(",", parameters.Select(p => p.ParameterName));

            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                $"exec CreateNewDemand {parameterNames}",
                parameters.ToArray()
            );

            return result;

        }

        public async Task<int> DeleteDemand(int DemandId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteDemand {DemandId}"));
        }

        public async Task<List<Demand>> GetAllDemand()
        {
            return await _dbContext.demands
                .FromSqlRaw<Demand>("GetAllDemands")
                .ToListAsync();
        }

        public async Task<IEnumerable<Demand>> GetDemandById(int DemandId)
        {
            var param=new SqlParameter("@DemandId",DemandId);

            var demandDetails = await Task.Run(() => _dbContext.demands
                .FromSqlRaw<Demand>(@"exec GetParticularDemand @DemandId", param)
                .ToListAsync());

            return demandDetails;
        }

        public async Task<int> UpdateDemand(Demand demand)
        {
            string skillsParameter = string.Join(",", demand.Skills);
            var parameters = new List<SqlParameter>
           {
                 new SqlParameter("@DemandId", demand.DemandId),
                 new SqlParameter("@DemandName", demand.DemandName),
                 new SqlParameter("@Email", demand.Email),
                 new SqlParameter("@Manager", demand.Manager),
                 new SqlParameter("@OpenPosition", demand.OpenPosition),
                 new SqlParameter("@Experience", demand.Experience),
                 new SqlParameter("@MaxBudget", demand.MaxBudget),
                 new SqlParameter("@NoticePeriod", demand.NoticePeriod),
                 new SqlParameter("@EmployeeType", demand.EmployeeType),
                 new SqlParameter("@Status", demand.Status),
                 new SqlParameter("@SkillName", skillsParameter),
                 new SqlParameter("@Location", demand.Location),
                 new SqlParameter("@AccountName", demand.Account_Name)
           };

            var parameterNames = string.Join(",", parameters.Select(p => p.ParameterName));

            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                $"exec UpdateDemand {parameterNames}",
                parameters.ToArray()
            );

            return result;

        }
    }
}
