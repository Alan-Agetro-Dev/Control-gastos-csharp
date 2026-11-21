namespace ControlGastos.Models;

// Representa un gasto registrado por el usuario.
public class Gasto
{
    // Descripción corta del gasto (por ejemplo: "Tacos").
    // "= string.Empty" evita advertencias de valor nulo.
    public string Descripcion { get; set; } = string.Empty;

    // Monto del gasto. Se usa decimal porque es el tipo correcto para dinero.
    public decimal Monto { get; set; }

    // Fecha y hora en que se registró. Se asigna sola al crear el gasto.
    public DateTime Fecha { get; set; } = DateTime.Now;
}