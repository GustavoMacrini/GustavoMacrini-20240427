using GestaoColaboradores.Models.Colaborador;
using GestaoColaboradores.Models.User;
using Microsoft.EntityFrameworkCore;

namespace GestaoColaboradores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        
    }
}
