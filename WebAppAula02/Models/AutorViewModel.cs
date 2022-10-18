using System.ComponentModel.DataAnnotations;

namespace WebAppAula02.Models
{
    public class AutorViewModel: Base
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        /* EF */
        public IEnumerable<LivroViewModel> Livros { get; set; }
    }


}
