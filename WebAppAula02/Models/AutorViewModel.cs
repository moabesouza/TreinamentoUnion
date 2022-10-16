using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WebAppAula02.Models
{
    public class AutorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<LivroViewModel> Livros { get; set; }
    }
}
