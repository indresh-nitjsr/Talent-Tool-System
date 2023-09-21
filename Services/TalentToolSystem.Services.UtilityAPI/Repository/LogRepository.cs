using Microsoft.Data.SqlClient;
using Serilog;
using System.Data.Common;
using System.Dynamic;
using TalentToolSystem.Services.UtilityAPI.Models;

namespace TalentToolSystem.Services.UtilityAPI.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly IConfiguration configuration;
        private readonly string dbconnection;
        private readonly string dateformat;

        public LogRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            dbconnection = this.configuration["ConnectionStrings:UtilityConnection"];
            //dateformat = this.configuration["Constants:DateFormat"];
        }
        public async Task<IEnumerable<CandidateLog>> GetAllCandidateLogs()
        {
            var logs = new List<CandidateLog>();
            using (SqlConnection connection = new(dbconnection))
            {
                SqlCommand command = new()
                {
                    Connection = connection,
                };

                string query = "SELECT * FROM CandidateLog";
                command.CommandText = query;
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var log = new CandidateLog()
                    {
                        Name = (string)reader["Name"],
                        Email = (string)reader["Email"],
                        Mobile = (string)reader["Mobile"],
                        CurrentCompany = (string)reader["CurrentCompany"],
                        Experience = (int)reader["Experience"],
                        Location = (string)reader["Location"],
                        CTC = (Decimal)reader["CTC"],
                        ECTC = (Decimal)reader["ECTC"],
                        NoticePeriod = (int)reader["NoticePeriod"],
                        EmployeeID = (int)reader["EmployeeID"],
                        Status = (string)reader["Status"],
                        TimeStamp = (DateTime)reader["TimeStamp"],
                    };
                    logs.Add(log);
                }
            }
            return logs;
            //var logs = new List<dynamic>();
            /*using (var connection = new SqlConnection(dbconnection))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM CandidateLog", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var log = new CandidateLog()
                            {
                                Name = (string)reader["Name"],
                                Email = (string)reader["Email"],
                                Mobile = (string)reader["Mobile"],
                                CurrentCompany = (string)reader["CurrentCompany"],
                                Experience = (int)reader["Experience"],
                                Location = (string)reader["Location"],
                                CTC = (Decimal)reader["CTC"],
                                ECTC = (Decimal)reader["ECTC"],
                                NoticePeriod = (int)reader["NoticePeriod"],
                                EmployeeID = (int)reader["EmployeeID"],
                                Status = (string)reader["Status"],
                                TimeStamp = (DateTime)reader["TimeStamp"],
                            };
                            logs.Add(log);
                        }
                        return logs;
                    }
                }
            }*/  
        }
    }
}
