using Microsoft.EntityFrameworkCore;
using SalaDigitalApi.Models;

namespace SalaDigitalApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().HasData(
                new Aluno { Id = 1, Nome = "Maria Silva", Email = "maria.silva@email.com", Idade = 20 },
                new Aluno { Id = 2, Nome = "João Pereira", Email = "joao.pereira@email.com", Idade = 22 },
                new Aluno { Id = 3, Nome = "Ana Souza", Email = "ana.souza@email.com", Idade = 19 }
            );
        }
    }
}
