public class Usuario
{
    public string id { get; set; }
    public string nombre { get; set; }
    public string password { get; set; }
    public bool login { get; set; }
    public Usuario(string nombre, string password, string id)
    {
        this.nombre = nombre;
        this.password = password;
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