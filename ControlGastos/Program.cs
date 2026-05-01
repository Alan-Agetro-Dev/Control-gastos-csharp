using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CONTROL DE GASTOS");

        // Llamamos al método que captura los gastos
        double total = CapturarGastos();

        // Mostramos el resultado final
        MostrarTotal(total);

        Console.ReadKey();
    }

    // Método para capturar múltiples gastos
    static double CapturarGastos()
    {
        double total = 0;
        string opcion = "s";

        while (opcion == "s")
        {
            Console.Write("Ingresa un gasto: ");
            double gasto = double.Parse(Console.ReadLine());

            total += gasto;

            Console.Write("¿Deseas agregar otro gasto? (s/n): ");
            opcion = Console.ReadLine();
        }

        return total;
    }

    // Método para mostrar el total
    static void MostrarTotal(double total)
    {
        Console.WriteLine($"Total de gastos: ${total}");
    }
}