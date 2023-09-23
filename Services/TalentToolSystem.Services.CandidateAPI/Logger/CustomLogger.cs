﻿using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Data;
using TalentToolSystem.Services.CandidateAPI.Model;

namespace TalentToolSystem.Services.UtilityAPI.Logger
{
    public class CustomLogger
    {
        static CustomLogger()
        {
            var sinkOptions = new MSSqlServerSinkOptions()
            {
                TableName = "CandidateLog",
                AutoCreateSqlTable = true
            };
            var connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=UtilityDb;Integrated Security=True;TrustServerCertificate=True;";

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .WriteTo.MSSqlServer(connectionString, sinkOptions, null, null,
            Serilog.Events.LogEventLevel.Information, columnOptions: GetColumnOptions())
           .CreateLogger();
        }


        public static ColumnOptions GetColumnOptions()
        {
            var columnOptions = new ColumnOptions();

            // Override the default Primary Column of Serilog by custom column name
            columnOptions.Id.ColumnName = "LogId";


            // Removing all the default column
            columnOptions.Store.Remove(StandardColumn.TimeStamp);
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Level);
            columnOptions.Store.Remove(StandardColumn.Exception);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Properties);


            // Adding all the custom columns
            columnOptions.AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "CandidateID", AllowNull = false},
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Name",DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Email", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Mobile", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "CurrentCompany", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "SkillSet", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "Experience", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Location", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Decimal, ColumnName = "CTC", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Decimal, ColumnName = "ECTC", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "NoticePeriod", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "ReferralId", AllowNull = true },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Status", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Manager", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Account", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.DateTime2, ColumnName = "TimeStamp", AllowNull = false },
            };
            return columnOptions;
        }

        public static void Information(Candidate candidate)
        {
            if (candidate == null)
            {
                Log.Logger.Error("Object reference not set to an instance of an object.");
            }
            else
            {
                Log.Logger.Information("{CandidateID}{Name}{Email}{Mobile}{CurrentCompany}{SkillSet}{Experience}{Location}{CTC}{ECTC}{NoticePeriod}{ReferralId}{Status}{Manager}{Account}{TimeStamp}",
                    candidate.CandidateId, candidate.CandidateName, candidate.Email, candidate.Mobile, candidate.CurrentCompany,
                    candidate.SkillSet, candidate.YearOfExperience, candidate.Location, candidate.CTC, candidate.ECTC, candidate.NoticePeriod, 
                    candidate.ReferralId, candidate.Status,candidate.Manager, candidate.Account, DateTime.Now
                    );
            }
        }
    }
}