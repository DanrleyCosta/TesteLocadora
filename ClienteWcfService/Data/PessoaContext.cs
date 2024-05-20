using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClienteWcfService.ModelCliente;

namespace ClienteWcfService.Data
{
    public class PessoaContext : DbContext
    {
        // todas devem esta no plural devido a alguns padrões de outras ORMs
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-HKBV533R\\SQLEXPRESS02;Initial Catalog =testepuc; Integrated Security=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity < entidade com chave Composta N-N > (entity =>
        //        {
        //            entity.HasKey(e => new { })
  
        //        });
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<Funcionario>().HasRequired<Empresa>(s => s.CurrentGrade)
        //        .WithMany(g => g.Students)
        //        .HasForeignKey<int>(s => s.CurrentGradeId);
        //}
    }
}
