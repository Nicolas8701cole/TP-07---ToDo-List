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
            if (Acciones.ConfirmarUsuarioExiste(usuario, clave) == 1)
            {
                return View("Page");
            }
            else if (Acciones.RegistrarUsuarios(usuario, clave) == 1)
            {
                return View("Page");
            }
        }
        return RedirectToAction("Index", "Home");
    }
    public IActionResult AdministrarMovimientosEntrePestañas(int eleccion)
    {
        if (eleccion == 1)
        {
            return View("IniciarSesion");
        }
        else if (eleccion == 2)
        {
            return View("Registrarse");
        }
        else
        {
            return View("Creditos");
        }
    }
    //public IActionResult AgregarComida(string Nombre, int IdTipoComida, double Precio, bool SinGluten)
    //{
    //Comidas coco = new Comidas(Nombre, IdTipoComida, Precio, SinGluten);
    //BD.AgregarComidas(coco);
    //return RedirectToAction("Index");
    //}
}
