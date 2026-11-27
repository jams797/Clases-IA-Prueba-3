using System;
using System.Collections.Generic;

namespace ConexionDB.Models;

public partial class Ciudad
{
    public int CiudadId { get; set; }

    public string? CiudadNombre { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
