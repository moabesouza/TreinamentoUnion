using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using WebAppAula02.Models;

namespace WebAppAula02.Auxiliar
{
    //classe de iplementação dos metodos da interface ISecao.cs
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext) //construtor com ijeção de idependencias
        {
            _httpContext = httpContext; 
        }
        public UsuarioViewModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");//buscando string de sessão
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;//verificação
            return JsonConvert.DeserializeObject<UsuarioViewModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioViewModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario); //Converter objeto usuario em string
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor); //guardando dados do usuario longado
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
