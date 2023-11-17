using System;
using System.Collections.Generic;

namespace Leccion_Parraga_Naula_BE.Models;

public partial class MaterialesUtilizado
{
    public int ReparacionId { get; set; }

    public string Material { get; set; } = null!;

    public int? Cantidad { get; set; }

    public virtual Reparacione Reparacion { get; set; } = null!;
}
