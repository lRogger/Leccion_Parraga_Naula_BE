using System;
using System.Collections.Generic;

namespace Leccion_Parraga_Naula_BE.Models;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public int? ClienteId { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();
}
