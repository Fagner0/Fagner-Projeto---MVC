using Microsoft.EntityFrameworkCore;
using Fagner_Projeto___MVC.Models;

namespace Fagner_Projeto___MVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alimento> Alimentos { get; set; }

        public DbSet<Exercicio> Exercicios { get; set; }

        public DbSet<FichaDeTreino> Fichas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fagner_Projeto___MVC.Models.Plano> Plano { get; set; }
    }
}
