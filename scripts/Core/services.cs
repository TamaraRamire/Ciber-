using System;
using System.Data.SqlClient;
using Dapper;

public class CiberService
{
    private readonly string _connectionString = "your_connection_string_here"; 

 
    public void CrearCuenta(Cuenta cuenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "INSERT INTO Cuenta (nombre, pass, dni, horaRegistrada) VALUES (@Nombre, @Pass, @Dni, @HoraRegistrada)";
            connection.Execute(sql, cuenta);
        }
    }

    public IEnumerable<Cuenta> ObtenerCuentas()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "SELECT * FROM Cuenta";
            return connection.Query<Cuenta>(sql);
        }
    }


    public void ActualizarCuenta(Cuenta cuenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "UPDATE Cuenta SET nombre = @Nombre, pass = @Pass, dni = @Dni, horaRegistrada = @HoraRegistrada WHERE Ncuenta = @Ncuenta";
            connection.Execute(sql, cuenta);
        }
    }

    public void EliminarCuenta(int Ncuenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "DELETE FROM Cuenta WHERE Ncuenta = @Ncuenta";
            connection.Execute(sql, new { Ncuenta });
        }
    }
}
