using WebAppAula02.Enums;

namespace WebAppAula02.Models
{
    public class UsuarioViewModel : Base
    {
        
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)//verificando se a senha e valida
        {
            return Senha == senha;
        }

    }

    
}
