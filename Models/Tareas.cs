
using Newtonsoft.Json;
public class Tareas
{
    public int id { get; set; }
    public int estado { get; set; } //hecha = 1, En proceso = 2, no empezada = 3
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public int propietario { get; set; }
    public DateTime fecha { get; set; }
    public bool eliminado { get; set; }
    public List<Usuario> compartido { get; set; }
    public Tareas(int id, int estado, string nombre, string descripcion, int propietario, DateTime fecha, bool eliminado)
    {
        this.id = id;
        this.estado = estado;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.propietario = propietario;
        this.fecha = fecha;
        this.eliminado = eliminado;
    }
}