using System.Linq;
using ControlGastos.Interfaces;
using ControlGastos.Models;

namespace ControlGastos.Services;

// Lógica de negocio de los gastos.
// Depende de la interfaz IGastoRepository, no de una implementación concreta.
public class GastoService
{
    private readonly IGastoRepository _repositorio;

    // El repositorio llega desde afuera (inyección de dependencias).
    public GastoService(IGastoRepository repositorio)
    {
        _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
    }

    // Valida y registra un gasto nuevo. Devuelve el gasto creado.
    public Gasto Registrar(string descripcion, decimal monto)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
            throw new ArgumentException("La descripción es obligatoria.", nameof(descripcion));

        if (monto <= 0)
            throw new ArgumentException("El monto debe ser mayor que cero.", nameof(monto));

        var gasto = new Gasto
        {
            Descripcion = descripcion.Trim(), // Quita espacios sobrantes
            Monto = monto
        };

        _repositorio.Agregar(gasto);
        return gasto;
    }

    // Devuelve el historial completo de gastos.
    public IReadOnlyList<Gasto> ObtenerTodos()
    {
        return _repositorio.ObtenerTodos();
    }

    // Calcula el total acumulado con LINQ.
    // Sum suma el Monto de cada gasto; si no hay gastos, devuelve 0.
    public decimal CalcularTotal()
    {
        return _repositorio.ObtenerTodos().Sum(g => g.Monto);
    }
}