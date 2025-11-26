using System;

namespace Infrastructure.Logging;

public static class Logger
{
    // Se maneja como propiedad para permitir habilitar o deshabilitar el registro dinámicamente
    public static bool Enabled { get; set; } = true;

	public static void Log(string message)
	{
		if (!Enabled) return;
		Console.WriteLine("[LOG] " + DateTime.Now + " - " + message);
	}

	public static void Try(Action a)
	{
		try
		{
			a();
		}
		catch (Exception)
		{
            // La excepción se omite de forma deliberada
            // Este enfoque evita que errores secundarios impacten la lógica principal
        }
    }
}