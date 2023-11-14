using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Codigo { get; set; }
    [Required]
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    [Column(TypeName = "decimal(18,2)")] 
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public decimal CalcularSubtotal()
    {
        return Precio * Cantidad;
    }
}