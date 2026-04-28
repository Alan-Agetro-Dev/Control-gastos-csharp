using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CONTROL DE GASTOS");

        // Pedimos un gasto al usuario
        Console.Write("Ingresa un gasto: ");

        // Leemos lo que el usuario escribe
        string entrada = Console.ReadLine();

        // Convertimos el texto a número
        double gasto = double.Parse(entrada);

        // Mostramos el valor ingresado
        Console.WriteLine($"Gasto ingresado: ${gasto}");

        Console.ReadKey();
    }
}