using System;
using System.Collections.Generic;

namespace portal_proveedores.Models;

public partial class Usuario
{
    public string NroDoc { get; set; } = null!;

    public string? NombreCompleto { get; set; }

    public string? Usuario1 { get; set; }

    public string? Clave { get; set; }

    public string? Perfil { get; set; }
}
