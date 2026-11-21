using ControlGastos.Models;

namespace ControlGastos.Interfaces;

// Contrato para guardar y consultar gastos.
// El servicio dependerá de esta interfaz, no de cómo se almacenan los datos.
public interface IGastoRepository
{
    // Guarda un gasto nuevo.
    void Agregar(Gasto gasto);

    // Devuelve todos los gastos registrados (lista vacía si no hay ninguno).
    IReadOnlyList<Gasto> ObtenerTodos();
}