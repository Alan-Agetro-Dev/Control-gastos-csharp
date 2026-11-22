# Control de Gastos

Aplicación de consola en C# para registrar gastos, consultar el historial y calcular el total acumulado. Es un proyecto de práctica enfocado en separar responsabilidades con una arquitectura sencilla por capas.

## Funcionalidades

- Registrar gastos con descripción, monto y fecha (la fecha se asigna automáticamente).
- Ver el historial de gastos, numerado y con fecha y hora.
- Calcular el total acumulado.
- Validación de datos: la descripción es obligatoria y el monto debe ser un número mayor que cero.
- Sin límite de gastos: se guardan en una lista en memoria.

## Conceptos que aplica

- **Programación orientada a objetos:** la entidad `Gasto` y clases con una sola responsabilidad.
- **Patrón Repository:** el servicio depende de la interfaz `IGastoRepository` y no de cómo se guardan los datos.
- **Inyección de dependencias (manual):** el repositorio se entrega al servicio por el constructor.
- **LINQ:** el total se calcula con `Sum`.
- **Validación de entrada:** `decimal.TryParse` evita que el programa se caiga con datos incorrectos.
- **Manejo de excepciones:** los errores de validación del servicio se capturan y se muestran en consola.

## Estructura del proyecto

```
ControlGastos/
├── ControlGastos.slnx
└── ControlGastos/
    ├── Models/
    │   └── Gasto.cs
    ├── Interfaces/
    │   └── IGastoRepository.cs
    ├── Repositories/
    │   └── GastoRepositoryMemoria.cs
    ├── Services/
    │   └── GastoService.cs
    └── Program.cs
```

- **Models:** la entidad `Gasto`.
- **Interfaces:** el contrato `IGastoRepository`.
- **Repositories:** la implementación que guarda en memoria con `List<Gasto>`.
- **Services:** la lógica de negocio (validaciones y total).
- **Program.cs:** el menú de consola.

## Requisitos

- SDK de .NET instalado (se puede comprobar con `dotnet --version`).

## Cómo ejecutarlo

```bash
git clone https://github.com/Alan-Agetro-Dev/Control-gastos-csharp.git
cd Control-gastos-csharp/ControlGastos
dotnet run
```

Al escribir montos con decimales, usa el separador de tu sistema (punto o coma).

## Ejemplo de uso

```
=== CONTROL DE GASTOS ===
1. Registrar gasto
2. Ver historial
3. Ver total
0. Salir
```

## Limitaciones y próximos pasos

- Los datos se guardan solo en memoria y se pierden al cerrar el programa.
- Posible mejora: guardar los gastos en SQL Server con procedimientos almacenados. Como el servicio depende de una interfaz, bastaría con una nueva implementación del repositorio.
- Posible mejora: excepciones personalizadas y reportes adicionales con LINQ.

## Autor

Alan Ortega