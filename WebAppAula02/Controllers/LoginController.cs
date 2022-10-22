using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebAppAula02.Auxiliar;
using WebAppAula02.Data;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;
using System;

namespace WebAppAula02.Controllers
{

    public class LoginController : Controller

       
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //se usuario estiver logado redirecionar para tela home

            if (_sessao.BuscarSessaoUsuario() !=null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar (LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   UsuarioViewModel  usuario = _usuarioRepository.BuscarLogin(loginViewModel.Login);//retornando objeto Usuario Model
                   if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginViewModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");//redirecionando para Action Index e contoller Home
                        }
                        
                    }
                    
                    
                    
                }
                return View("Index");
            }
            catch 
            {
                return RedirectToAction("Index");
            }
        }
    }
}
