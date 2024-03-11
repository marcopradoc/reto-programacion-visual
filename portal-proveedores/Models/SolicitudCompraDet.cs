using System;
using System.Collections.Generic;

namespace portal_proveedores.Models;

public partial class SolicitudCompraDet
{
    public int CodSolCom { get; set; }

    public int CodSolComDet { get; set; }

    public int? CodProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }
}
