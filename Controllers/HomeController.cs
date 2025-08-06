using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP03.Models;

namespace TP03.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
        public IActionResult Login(string usuario, string password)
    {
        if (string.IsNullOrWhiteSpace(usuario) == false)
        {
            //Contenido contenido = new Contenido();
            //Jugador jugador = new Jugador(usuario, password);
            //HttpContext.Session.SetString("jugador", Objeto.ObjectToString(jugador));//Permite llevar un objeto a jeson

            //jugador = Objeto.StringToObject<Jugador>(HttpContext.Session.GetString("jugador"));//Permite traer un jason a objeto

            //contenido.InicializarContenido();
            return RedirectToAction("Habitacion");
        }
        else { Console.WriteLine("Ya existe"); }

        return View("Login");
    }
}
