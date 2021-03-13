using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Text;

namespace ExcelSemanticSearch
{
    public class ExcelContext: DbContext
    {
        private const string connectionString = "Server=DESKTOP-A9FV0B7;Database=AdventureWorks2014;User Id=sa;Password=Aa123456;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Person> Documents { get; set; }
    }
}
