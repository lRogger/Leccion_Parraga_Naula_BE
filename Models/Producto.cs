using System;
using System.Collections.Generic;

namespace Leccion_Parraga_Naula_BE.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }
}
