using System;
using System.Collections.Generic;

namespace Leccion_Parraga_Naula_BE.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public string? Cargo { get; set; }

    public decimal? Salario { get; set; }
}
