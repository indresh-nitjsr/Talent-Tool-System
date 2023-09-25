﻿using System;
using System.Collections.Generic; 
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentToolSystem.Services.DemandAPI.Model;
using Microsoft.Extensions.Options;

namespace TalentToolSystem.Services.DemandAPI.Data
{
    public class DemandContext:DbContext
    {
        public DbSet<Demand> demands { get; set; }

        public DemandContext(DbContextOptions<DemandContext> options) : base(options)
        {

        }

       

       
       /* protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                string? connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* var StringValueConverter = new ValueConverter<IEnumerable<string>, string>(
                                v => string.Join(',', v),
                                               v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
             modelBuilder
                 .Entity<Demand>()
                 .Property(e => e.Skills)
                 .HasConversion(StringValueConverter);*/

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = 1,
                DemandName = "Python Developer",
                Email = "nexturn@gmail.com",
                Account_Name = "Amazon",
                Manager = "Gunjan",
                OpenPosition = 1,
                Experience = 1,
                MaxBudget = 10,
                NoticePeriod = 2,
                EmployeeType = "FTE",
                Status = "Selected",
                Skills = "C++,.Net,Sql Server",
                Location = "Hyderabad"
            });

            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = 2,
                DemandName = "Java Developer",
                Email = "nexturn@gmail.com",
                Account_Name = "Amazon",
                Manager = "Gunjan",
                OpenPosition = 1,
                Experience = 1,
                MaxBudget = 10,
                NoticePeriod = 2,
                EmployeeType = "FTE",
                Status = "Selected",
                Skills = "C++,.Net,Sql Server",
                Location = "Hyderabad"
            });

            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = 3,
                DemandName = ".Net Developer",
                Email = "nexturn@gmail.com",
                Account_Name = "Amazon",
                Manager = "Gunjan",
                OpenPosition = 1,
                Experience = 1,
                MaxBudget = 10,
                NoticePeriod = 2,
                EmployeeType = "FTE",
                Status = "Selected",
                Skills = "C++,.Net,Sql Server",
                Location = "Hyderabad"
            });
        }
    }
}
