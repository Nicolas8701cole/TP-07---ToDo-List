
using Newtonsoft.Json;
public class Jugador
{
    public string nombre { get; set; }
    public string pasword { get; set; }
    public int habitacionActual { get; set; }
    public Jugador(string nombre, string pasword)
    {
        this.nombre = nombre;
        this.pasword = pasword;
        this.habitacionActual = 0;
    }

    public void Avanzar()
    {
        habitacionActual++;
    }
}