using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Required]
    
    public  string Nombre { get; set; }
    [Required]
    [Range(0, float.MaxValue)]
    public float Precio { get; set; }
    [Required]
    [Range(0, float.MaxValue)]
    public int Cantidad { get; set; }
   
    public float Descuento { get; set; }
    [Required]
    [Range(0, float.MaxValue)]
    public float Iva { get; set; }
}