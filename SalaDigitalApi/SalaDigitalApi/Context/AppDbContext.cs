using Microsoft.EntityFrameworkCore;
using SalaDigitalApi.Models;

namespace SalaDigitalApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Maria Silva", Email = "maria.silva@email.com", Age = 20 },
                new Student { Id = 2, Name = "João Pereira", Email = "joao.pereira@email.com", Age = 22 },
                new Student { Id = 3, Name = "Ana Souza", Email = "ana.souza@email.com", Age = 19 }
            );
        }
    }
}
