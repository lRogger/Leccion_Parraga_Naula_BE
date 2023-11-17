using System;
using System.Collections.Generic;

namespace Leccion_Parraga_Naula_BE.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
