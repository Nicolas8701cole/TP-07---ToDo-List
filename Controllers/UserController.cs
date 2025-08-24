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
    [HttpPost]
    public IActionResult Login(string usuario, string clave)
    {
        if (string.IsNullOrWhiteSpace(usuario) == false && string.IsNullOrWhiteSpace(clave) == false)
        {
            if (Acciones.ConfirmarUsuarioExiste(usuario, clave) == 1)
            {
                Usuario usuario1 = Acciones.ObtenerUsuario(usuario);
                if (usuario1 != null)
                {
                    HttpContext.Session.SetString("usuario", Objeto.ObjectToString(usuario1));//Permite llevar un objeto a jeson
                    return View("Page");
                }
            }
            else
            {
                return RedirectToAction("Registrarse", "Home");
            }
        }
        return RedirectToAction("Index", "Home");
    }
    public IActionResult Registrarse(string usuario, string clave)
    {
        if (string.IsNullOrWhiteSpace(usuario) == false && string.IsNullOrWhiteSpace(clave) == false)
        {
            if (Acciones.ConfirmarNombreExiste(usuario) == 0)
            {
                Acciones.Registro(usuario, clave);
                Usuario usuario1 = Acciones.ObtenerUsuario(usuario);
                if (usuario1 != null)
                {
                    HttpContext.Session.SetString("usuario", Objeto.ObjectToString(usuario1));//Permite llevar un objeto a jeson
                    return View("Page");
                }
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Home");
            }
        }
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AdministrarMovimientosEntrePestañas(int eleccion)
    {
        if (eleccion == 1)
        {
            Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
            ViewBag.dato = Acciones.LevantarTareasNoEliminadas(usuario.id);
            return View("MostrarTarea");
        }
        else if (eleccion == 2)
        {
            Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
            ViewBag.dato = Acciones.LevantarTareasNoEliminadas(usuario.id);
            return View("CrearTarea");
        }
        else if (eleccion == 3)
        {
            Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
            ViewBag.dato = Acciones.LevantarTareasNoEliminadas(usuario.id);
            return View("EditarTarea");
        }
        else if (eleccion == 4)
        {
            Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
            ViewBag.dato = Acciones.LevantarTareasNoEliminadas(usuario.id);
            return View("BorrarTarea");
        }
        else if (eleccion == 5)
        {
            Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
            ViewBag.dato = Acciones.LevantarTareasNoEliminadas(usuario.id);
            return View("CompartirTarea");
        }
        else if (eleccion == 6)
        {
            Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
            ViewBag.dato = Acciones.LevantarTareasNoEliminadas(usuario.id);
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
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    public IActionResult MarcarComoFinalizado(int idTarea)
    {
        Acciones.MarcarComoFinalizado(idTarea);
        return View("Page");
    }
    public IActionResult MandarAEditarTarea(int idTarea)
    {
        Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        var tareas = Acciones.LevantarTareasNoEliminadas(usuario.id);
        var tareaSeleccionada = tareas.FirstOrDefault(t => t.id == idTarea);
        ViewBag.tarea = tareaSeleccionada;
        return View("EditarTareaEspecifica");
    }
    public IActionResult MandarACompartirTarea(int idTarea)
    {
        Usuario usuario = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("usuario"));
        var tareas = Acciones.LevantarTareasNoEliminadas(usuario.id);
        var tareaSeleccionada = tareas.FirstOrDefault(t => t.id == idTarea);
        ViewBag.tarea = tareaSeleccionada;
        ViewBag.idTarea = idTarea;
        return View("AQuienLeCompartiras");
    }
    public IActionResult GuardarEdicionDeTarea(int id, string nombreTarea, string descripcionTarea, DateTime fecha, int estadoTarea)
    {
        Acciones.ModificarTarea(id, estadoTarea, nombreTarea, descripcionTarea, fecha);
        return View("Page");
    }
    public IActionResult ComperteTarea(string nombreUsuario, int idTarea)
    {
        Usuario idUsuario = Acciones.ObtenerUsuario(nombreUsuario);
        Acciones.CompartirTarea(idUsuario.id, idTarea);
        return View("Page");
    }
    //public IActionResult AgregarComida(string Nombre, int IdTipoComida, double Precio, bool SinGluten)
    //{
    //Comidas coco = new Comidas(Nombre, IdTipoComida, Precio, SinGluten);
    //BD.AgregarComidas(coco);
    //return RedirectToAction("Index");
    //}
    public IActionResult BorrarTarea(int idTarea)
    {
        Acciones.EliminarTarea(idTarea);
        return View("Page");
    }
}
