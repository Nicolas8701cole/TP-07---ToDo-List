using Microsoft.Data.SqlClient;
using Dapper;
using System;

public static class Acciones
{
    //Linea para conectar a bd antigua
    //private static string _connectionString = @"Server=localhost;DataBase=TP07-ToDoList;Integrated Security=True;TrustServerCertificate=True;";
    //Linea para conectar a bd nueva
    private static string _connectionString = @"Server=MSI\SQLEXPRESS;DataBase=TP07-ToDoList;Integrated Security=True;TrustServerCertificate=True;";
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

    public static List<Tareas> LevantarTareasNoEliminadas(int usuario)
    {
        List<Tareas> tareas = new List<Tareas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string storedProcedure = "LevantarTareasNoEliminadas";
            tareas = connection.Query<Tareas>
            (storedProcedure, new { usuario = usuario },
             commandType: System.Data.CommandType.StoredProcedure).ToList();  //cuando devuelve 0 es que no existe 1 si
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
    public static int ConfirmarNombreExiste(string usuario)
    {
        int existe = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string storedProcedure = "ConfirmarNombreExiste";
            existe = connection.QueryFirstOrDefault<int>
            (storedProcedure, new { Nombre = usuario }, commandType: System.Data.CommandType.StoredProcedure);  //cuando devuelve 0 es que no existe 1 si
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
    public static void AgregarTarea(Tareas tareas, int propietario)
    {
        const string query = @"INSERT INTO Tareas (estado, nombre, descripcion, propietario, fecha, eliminado, compartido)
                           VALUES (@estado, @nombre, @descripcion, @propietario, @fecha, @eliminado, @compartido)";
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new
            {
                estado = tareas.estado,
                nombre = tareas.nombre,
                descripcion = tareas.descripcion,
                propietario = propietario,
                fecha = tareas.fecha,
                eliminado = tareas.eliminado,
                compartido = tareas.compartido
            });
        }
    }
    public static int EliminarTarea(int idTarea)
    {
        const string query = "UPDATE Tareas SET eliminado = 1 WHERE id = @idTarea";
        using (var connection = new SqlConnection(_connectionString))
        {
            return connection.Execute(query, new { idTarea });
        }
    }

    public static void ModificarTarea(int id, int estado, string nombre, string descripcion, DateTime fecha)
    {
        string query = "UPDATE Tareas SET estado=@estado, nombre=@nombre, descripcion=@descripcion, fecha=@fecha WHERE id=@id AND eliminado=0";
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { id, estado, nombre, descripcion, fecha });
        }
    }
    public static Usuario ObtenerUsuario(string nombre)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE Nombre = @Nombre";
            return connection.QueryFirstOrDefault<Usuario>(query, new { Nombre = nombre });
        }
    }
    public static void MarcarComoFinalizado(int idTarea)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Execute("MarcarComoFinalizado",
                new { idd = idTarea },
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
    public static void Registro(string nombre, string clave)
    {
        int existe = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string storedProcedure = "Registro";
            existe = connection.QueryFirstOrDefault<int>
            (storedProcedure, new { Nombre = nombre, Clave = clave }, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
    public static void CompartirTarea(int idUsuario, int idTarea)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Execute("CompartirTarea",
                new { IdUsuario = idUsuario, IdTarea = idTarea },
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}