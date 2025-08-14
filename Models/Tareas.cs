
using Newtonsoft.Json;
public class Tareas
{
    public int id { get; set; }
    public string estado { get; set; } //hecha = 1, En proceso = 2, no empezada = 3
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public int propietario { get; set; }
    public DateTime fecha { get; set; }
    public bool eliminado { get; set; }
    public bool compartido { get; set; }
    

    public Tareas()
    {

    }
}