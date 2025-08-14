public class Usuario
{
    public string id { get; set; }
    public string nombre { get; set; }
    public string clave { get; set; }
    public bool login { get; set; }
    public Usuario(){} 
    public Usuario(string nombre, string clave, string id)
    {
        this.nombre = nombre;
        this.clave = clave;
        this.login = false;
        this.id = id;
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