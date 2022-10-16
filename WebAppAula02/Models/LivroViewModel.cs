using System.ComponentModel.DataAnnotations;

namespace WebAppAula02.Models
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int AutorId { get; set; }
        public bool Emprestado { get; set; }
    }
}
