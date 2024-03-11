using System;
using System.Collections.Generic;

namespace portal_proveedores.Models;

public partial class Proveedor
{
    public string Ruc { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Contacto { get; set; }

    public int? Partnership { get; set; }
}
