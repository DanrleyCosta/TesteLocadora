using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace testePessoa.Models
{
    public class Context : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // "Data Source=LAPTOP-HKBV533R\\SQLEXPRESS02;Initial Catalog =testepuc; Integrated Security=True;"
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnTeste"].ConnectionString);
        }
    }
}
