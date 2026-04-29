using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CONTROL DE GASTOS");

        // Pedimos un gasto al usuario
        Console.Write("Ingresa un gasto: ");
        string entrada = Console.ReadLine();

        // Intentamos convertir el texto a número
        bool esNumero = double.TryParse(entrada, out double gasto);

        // Validamos el resultado
        if (esNumero && gasto > 0)
        {
            Console.WriteLine($"Gasto válido: ${gasto}");
        }
        else
        {
            Console.WriteLine("Entrada inválida. Ingresa un número mayor a 0.");
        }

        Console.ReadKey();
    }
}