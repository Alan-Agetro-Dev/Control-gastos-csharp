using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CONTROL DE GASTOS");

        double[] gastos = new double[10]; // Arreglo para guardar gastos
        int contador = 0; // Controla cuántos gastos llevamos

        double total = CapturarGastos(gastos, ref contador);
        MostrarHistorial(gastos, contador);
        MostrarTotal(total);

        Console.ReadKey();
    }

    // Método para capturar gastos
    static double CapturarGastos(double[] gastos, ref int contador)
    {
        double total = 0;
        string opcion = "s";

        while (opcion == "s" && contador < gastos.Length)
        {
            Console.Write("Ingresa un gasto: ");
            double gasto = double.Parse(Console.ReadLine());

            gastos[contador] = gasto; // Guardamos el gasto en el arreglo
            contador++;

            total += gasto;

            Console.Write("¿Deseas agregar otro gasto? (s/n): ");
            opcion = Console.ReadLine();
        }

        return total;
    }

    // Método para mostrar el historial de gastos
    static void MostrarHistorial(double[] gastos, int contador)
    {
        Console.WriteLine("\nHistorial de gastos:");

        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine($"Gasto {i + 1}: ${gastos[i]}");
        }
    }

    // Método para mostrar el total
    static void MostrarTotal(double total)
    {
        Console.WriteLine($"\nTotal de gastos: ${total}");
    }
}