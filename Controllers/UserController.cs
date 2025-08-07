using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP03.Models;

namespace TP03.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    public IActionResult Login(string usuario, string clave)
    {
        if (string.IsNullOrWhiteSpace(usuario) == false)
        {
            if (Acciones.ConfirmarUsuarioExiste(usuario, clave) == 1){
                
            }
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

    //public IActionResult AgregarComida(string Nombre, int IdTipoComida, double Precio, bool SinGluten)
    //{
        //Comidas coco = new Comidas(Nombre, IdTipoComida, Precio, SinGluten);
        //BD.AgregarComidas(coco);
        //return RedirectToAction("Index");
    //}
}
