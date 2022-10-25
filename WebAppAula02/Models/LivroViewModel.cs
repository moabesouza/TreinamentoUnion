using System.ComponentModel.DataAnnotations;

namespace WebAppAula02.Models
{
    public class LivroViewModel: Base
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Sinopse { get; set; }
        public int AutorId { get; set; }
        public bool Emprestado { get; set; }

        /* EF Relations */
        public AutorViewModel Autores { get; set; }
        
    }
}
