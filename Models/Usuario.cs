public class Usuario
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string clave { get; set; }
    public bool login { get; set; }
    public Usuario(){} 
    public Usuario(string nombre, string clave)
    {
        this.nombre = nombre;
        this.clave = clave;
        this.login = false;
    }
    public void IniciarSesion()
    {
        login = true;
    }
    public void CerrarSesion()
    {
        login = false;
    }
}