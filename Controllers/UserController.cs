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
                return RedirectToAction("Page");
            }
        }
        else { Console.WriteLine("Ya existe"); }

        return View("Index");
    }

    //public IActionResult AgregarComida(string Nombre, int IdTipoComida, double Precio, bool SinGluten)
    //{
        //Comidas coco = new Comidas(Nombre, IdTipoComida, Precio, SinGluten);
        //BD.AgregarComidas(coco);
        //return RedirectToAction("Index");
    //}
}
