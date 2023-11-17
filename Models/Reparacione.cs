using System;
using System.Collections.Generic;

namespace Leccion_Parraga_Naula_BE.Models;

public partial class Reparacione
{
    public int ReparacionId { get; set; }

    public int? VehiculoId { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual ICollection<MaterialesUtilizado> MaterialesUtilizados { get; set; } = new List<MaterialesUtilizado>();

    public virtual Vehiculo? Vehiculo { get; set; }
}
