using System;
using System.Collections.Generic;

namespace portal_proveedores.Models;

public partial class Producto
{
    public int CodProducto { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }
}
