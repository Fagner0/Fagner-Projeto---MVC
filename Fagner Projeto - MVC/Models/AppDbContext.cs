using Microsoft.EntityFrameworkCore;

namespace Fagner_Projeto___MVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alimento> Alimentos { get; set; }

        public DbSet<Exercicio> Exercicios { get; set; }
    }
}
