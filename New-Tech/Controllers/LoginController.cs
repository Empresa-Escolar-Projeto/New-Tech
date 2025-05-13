using Microsoft.AspNetCore.Mvc;
using New_Tech.Models;
using New_Tech.Repositorio;


namespace New_Tech.Controllers
{
    public class ClientesController : Controller
    {
        private readonly LoginRepositorio _loginRepositorio;

        public ClientesController(LoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }

        public IActionResult ChecarUsuario(string email)
        {
            var usuario = _loginRepositorio.ObterUsuario(email);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
    }
}

