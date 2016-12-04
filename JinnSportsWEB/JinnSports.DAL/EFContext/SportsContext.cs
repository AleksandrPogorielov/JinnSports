using System;
using System.Collections.Generic;
using System.Data.Entity;
using JinnSports.Entities;

namespace JinnSports.DAL.EFContext
{
    public class SportsContext : DbContext
    {
        public DbSet<CompetitionEvent> CompetitionEvents;
        public DbSet<Result> Results;
        public DbSet<SportType> SportTypes;
        public DbSet<Team> Teams;
       
        public SportsContext() : base("SportContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }
    }
}