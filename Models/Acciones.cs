using Microsoft.Data.SqlClient;
using Dapper;
using System;

public static class Acciones
{

    private static string _connectionString = @"Server=localhost;DataBase=TP07-ToDoList;Integrated Security=True;TrustServerCertificate=True;";

    public static List<Tareas> LevantarTareas()
    {
        List<Tareas> tareas = new List<Tareas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas";
            tareas = connection.Query<Tareas>(query).ToList();
        }
        return tareas;
    }
    public static List<Tareas> LevantarTareasNoEliminadas()
    {
        List<Tareas> tareas = new List<Tareas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "Execute LevantarTareasNoEliminadas";
            tareas = connection.Query<Tareas>(query).ToList();
        }
        return tareas;
    }
    public static List<Tareas> LevantarTareasEliminadas()
    {
        List<Tareas> tareas = new List<Tareas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "Execute LevantarTareasEliminadas";
            tareas = connection.Query<Tareas>(query).ToList();
        }
        return tareas;
    }
    public static List<Usuario> LevantarUsuario()
    {
        List<Usuario> usuario = new List<Usuario>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario";
            usuario = connection.Query<Usuario>(query).ToList();
        }
        return usuario;
    }
    public static int ConfirmarUsuarioExiste(string usuario, string clave)
    {
        int existe = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string storedProcedure = "Sesion";
            existe = connection.QueryFirstOrDefault<int>
            (storedProcedure, new { Nombre = usuario, clave = clave }, commandType: System.Data.CommandType.StoredProcedure);  //cuando devuelve 0 es que no existe 1 si
        }
        return existe;
    }
    public static int RegistrarUsuarios(string usuario, string clave)
    {
        int existe = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string storedProcedure = "Registro";
            existe = connection.QueryFirstOrDefault<int>
            (storedProcedure, new { Nombre = usuario, Clave = clave }, commandType: System.Data.CommandType.StoredProcedure);  //cuando devuelve 0 es que no existe 1 si
        }
        return existe;
    }
    public static void AgregarTarea(Tareas tareas)
    {
        string query = "INSERT INTO Tareas (estado, nombre, descripcion, propietario, fecha, eliminado) VALUES (@estado, @nombre, @descripcion, @propietario, @fecha, @eliminado)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { estado = tareas.estado, nombre = tareas.nombre, descripcion = tareas.descripcion, propietario = tareas.propietario, fecha = tareas.fecha, eliminado = tareas.eliminado });
        }
    }
    public static int EliminarTarea(int numeroDeTarea)
    //Usamos levantar tareas para darselas todas, que sean cliqueables de a uno y el que 
    //toca enviar envía el id de tarea que es para marcarla como eliminada esta parte desde
    //sql
    {
        string query = "Execute EliminarTarea numeroDeTarea";
        int registrosAfectados = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            registrosAfectados = connection.Execute(query);
        }
        return registrosAfectados;
    }
    public static void ModificarTarea(int id, int estado, string nombre, string descripcion, int propietario, DateTime fecha, bool eliminado)
    {//Me dan una tarea
        bool existe = false;
        for (int i = 0; i <= LevantarTareasNoEliminadas().Count; i++)
        {//Revisa si existe
            if (i + 1 == id)
            {
                existe = true;
            }
        }
        if (existe)
        {//Si existe
            string query = "UPDATE Tareas SET estado=@estado, nombre=@nombre, descripcion=@descripcion, propietario=@propietario, fecha=@fecha, eliminado=@eliminado WHERE id=@id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { nombre, descripcion, id });
            }
        }
    }
}