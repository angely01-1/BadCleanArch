using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Data;

using System.Data;
using Microsoft.Data.SqlClient;

public static class BadDb
{
    // Se expone como propiedad para permitir configurarla externamente
    // La cadena real (con credenciales) debe cargarse desde configuración segura como appsettings o secrets
    public static string ConnectionString { get; set; } = "Server=localhost;Database=master;TrustServerCertificate=True";

	public static int ExecuteNonQueryUnsafe(string sql)
	{
		var conn = new SqlConnection(ConnectionString);
		var cmd = new SqlCommand(sql, conn);
		conn.Open();
		return cmd.ExecuteNonQuery();
	}

	public static IDataReader ExecuteReaderUnsafe(string sql)
	{
        // Se ejecuta un reader utilizando la conexión actual sin validación adicional.
        var conn = new SqlConnection(ConnectionString);
		var cmd = new SqlCommand(sql, conn);
		conn.Open();
		return cmd.ExecuteReader();
	}
}