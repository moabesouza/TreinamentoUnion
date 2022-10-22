using WebAppAula02.Models;

namespace WebAppAula02.Auxiliar
{
    public interface ISessao
    {
        //metodos da sessão do usuario
        void CriarSessaoUsuario (UsuarioViewModel usuario);
        void RemoverSessaoUsuario();
        UsuarioViewModel BuscarSessaoUsuario();
    }
}
