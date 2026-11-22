using System.Globalization;
using ControlGastos.Repositories;
using ControlGastos.Services;

namespace ControlGastos;

class Program
{
    static void Main()
    {
        // Armamos las piezas: el servicio recibe el repositorio (inyección manual).
        var repositorio = new GastoRepositoryMemoria();
        var servicio = new GastoService(repositorio);

        bool salir = false;

        // El menú se repite hasta que el usuario elige salir.
        while (!salir)
        {
            MostrarMenu();
            string opcion = LeerTexto("Elige una opción: ");

            switch (opcion)
            {
                case "1":
                    RegistrarGasto(servicio);
                    break;
                case "2":
                    MostrarHistorial(servicio);
                    break;
                case "3":
                    MostrarTotal(servicio);
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    // Muestra las opciones del menú.
    static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== CONTROL DE GASTOS ===");
        Console.WriteLine("1. Registrar gasto");
        Console.WriteLine("2. Ver historial");
        Console.WriteLine("3. Ver total");
        Console.WriteLine("0. Salir");
    }

    // Pide los datos y registra el gasto a través del servicio.
    static void RegistrarGasto(GastoService servicio)
    {
        string descripcion = LeerTexto("Descripción: ");
        string textoMonto = LeerTexto("Monto: ");

        // TryParse no lanza excepción si el texto no es un número:
        // devuelve false y seguimos con un mensaje claro.
        if (!decimal.TryParse(textoMonto, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal monto))
        {
            Console.WriteLine("El monto debe ser un número válido.");
            return;
        }

        try
        {
            var gasto = servicio.Registrar(descripcion, monto);
            Console.WriteLine($"Gasto registrado: {gasto.Descripcion} - {gasto.Monto:C}");
        }
        catch (ArgumentException ex)
        {
            // Errores de validación del servicio (descripción vacía, monto <= 0).
            Console.WriteLine($"No se pudo registrar: {ex.Message}");
        }
    }

    // Muestra todos los gastos numerados.
    static void MostrarHistorial(GastoService servicio)
    {
        var gastos = servicio.ObtenerTodos();

        if (gastos.Count == 0)
        {
            Console.WriteLine("Aún no hay gastos registrados.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Historial de gastos:");
        for (int i = 0; i < gastos.Count; i++)
        {
            var gasto = gastos[i];
            Console.WriteLine($"{i + 1}. {gasto.Fecha:dd/MM/yyyy HH:mm} - {gasto.Descripcion}: {gasto.Monto:C}");
        }
    }

    // Muestra el total acumulado (calculado con LINQ en el servicio).
    static void MostrarTotal(GastoService servicio)
    {
        Console.WriteLine();
        Console.WriteLine($"Total de gastos: {servicio.CalcularTotal():C}");
    }

    // Lee una línea de la consola. ReadLine puede devolver null,
    // así que lo convertimos en texto vacío y quitamos espacios sobrantes.
    static string LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        return (Console.ReadLine() ?? string.Empty).Trim();
    }
}
