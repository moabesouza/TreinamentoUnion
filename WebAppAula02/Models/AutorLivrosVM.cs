using System.Collections;

namespace WebAppAula02.Models
{
    public class AutorLivrosVM 
    {
        public string Nome { get; set; }
        public IEnumerable<LivroViewModel> Livros { get; set; }
    }
}
