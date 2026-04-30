using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CONTROL DE GASTOS");

        // Variable para acumular el total de gastos
        double total = 0;

        // Variable para controlar el bucle
        string opcion = "s";

        // Bucle que se ejecuta mientras el usuario quiera continuar
        while (opcion == "s")
        {
            Console.Write("Ingresa un gasto: ");

            double gasto = double.Parse(Console.ReadLine());

            // Sumamos el gasto al total
            total += gasto;

            Console.Write("¿Deseas agregar otro gasto? (s/n): ");
            opcion = Console.ReadLine();
        }

        // Mostramos el total al final
        Console.WriteLine($"Total de gastos: ${total}");

        Console.ReadKey();
    }
}