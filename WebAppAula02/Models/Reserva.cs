using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppAula02.Models
{
    public class Reserva : Base
    {
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DiaReserva { get; set; }
        public DateTime DiaDevolucao { get; set; }

        /* EF */
        public LivroViewModel Livros { get; set; }
        public UsuarioViewModel Usuarios { get; set; }
    }
}
