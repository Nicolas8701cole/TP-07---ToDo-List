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
            ViewBag.dato = Acciones.LevantarTareas();
            return View("MostrarTarea");
        }
        else if (eleccion == 2)
        {
            ViewBag.dato = Acciones.LevantarTareas();
            return View("CrearTarea");
        }
        else if (eleccion == 3)
        {
            ViewBag.dato = Acciones.LevantarTareas();
            return View("EditarTarea");
        }
        else if (eleccion == 4)
        {
            ViewBag.dato = Acciones.LevantarTareas();
            return View("BorrarTarea");
        }
        else if (eleccion == 5)
        {
            ViewBag.dato = Acciones.LevantarTareas();
            return View("CompartirTarea");
        }
        else if (eleccion == 6)
        {
            ViewBag.dato = Acciones.LevantarTareas();
            return View("MarcarComoFinalizada");
        }
        else if (eleccion == 7)
        {
            return View("Page");
        }
        else
        {
            return View("Creditos");
        }
    }
    public IActionResult Desloguearse()
    {
        return RedirectToAction("Index", "Home");
    }
    public IActionResult MarcarComoFinalizado(int idTarea)
    {
        Acciones.MarcarComoFinalizado(idTarea);
        return View("Page");
    }
    public IActionResult MandarAEditarTarea(int idTarea)
    {
        var tareas = Acciones.LevantarTareas();
        var tareaSeleccionada = tareas.FirstOrDefault(t => t.id == idTarea);
        ViewBag.tarea = tareaSeleccionada;
        return View("EditarTareaEspesifica");
    }
        public IActionResult GuardarEdicionDeTarea(int idTarea)
    {
        var tareas = Acciones.LevantarTareas();
        var tareaSeleccionada = tareas.FirstOrDefault(t => t.id == idTarea);
        ViewBag.tarea = tareaSeleccionada;
        return View("EditarTareaEspesifica");
    }
    //public IActionResult AgregarComida(string Nombre, int IdTipoComida, double Precio, bool SinGluten)
    //{
    //Comidas coco = new Comidas(Nombre, IdTipoComida, Precio, SinGluten);
    //BD.AgregarComidas(coco);
    //return RedirectToAction("Index");
    //}
}
