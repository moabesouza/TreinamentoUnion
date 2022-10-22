using Microsoft.EntityFrameworkCore;
using WebAppAula02.Models;

namespace WebAppAula02.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AutorViewModel> Autores { get; set; }
        public DbSet<LivroViewModel> Livros { get; set; }
        public DbSet<EstudanteViewModel> Estudantes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<UsuarioViewModel> Usuarios { get; set; }

    }
}
