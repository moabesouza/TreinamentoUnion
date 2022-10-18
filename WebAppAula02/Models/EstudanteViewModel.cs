using System.ComponentModel.DataAnnotations;

namespace WebAppAula02.Models
{
    public class EstudanteViewModel: Base
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

    }
}
