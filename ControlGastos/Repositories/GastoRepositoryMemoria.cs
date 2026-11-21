using ControlGastos.Interfaces;
using ControlGastos.Models;

namespace ControlGastos.Repositories;

// Implementación de IGastoRepository que guarda los gastos en memoria.
// Los datos se pierden al cerrar el programa.
public class GastoRepositoryMemoria : IGastoRepository
{
    // Lista privada: solo esta clase puede modificarla.
    // "readonly" impide reemplazar la lista completa por otra.
    private readonly List<Gasto> _gastos = new();

    // Guarda un gasto nuevo al final de la lista.
    public void Agregar(Gasto gasto)
    {
        // Lanza un error claro si alguien intenta guardar un gasto nulo.
        ArgumentNullException.ThrowIfNull(gasto);

        _gastos.Add(gasto);
    }

    // Devuelve los gastos en modo solo lectura:
    // quien los reciba puede leerlos pero no agregar ni borrar.
    public IReadOnlyList<Gasto> ObtenerTodos()
    {
        return _gastos.AsReadOnly();
    }
}