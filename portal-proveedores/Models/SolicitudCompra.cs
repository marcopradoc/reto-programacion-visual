using System;
using System.Collections.Generic;

namespace portal_proveedores.Models;

public partial class SolicitudCompra
{
    public int CodSolCom { get; set; }

    public string? RucProveedor { get; set; }

    public string? Estado { get; set; }
}
