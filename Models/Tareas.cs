
using Newtonsoft.Json;
public class Tareas
{
    public string estado { get; set; } //En proceso, hecha, no empezada
    public string nombre { get; set; }
    public string descripcion {get; set;}
    public int propietario { get; set; }
    public DateTime fecha {get; set;}
    public bool eliminado { get; set; }   
    public Tareas (string estado, string nombre, string descripcion, int propietario, DateTime fecha, bool eliminado){
        this.estado = estado;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.propietario = propietario;
        this.fecha = fecha;
        this.eliminado = eliminado;
    }
}