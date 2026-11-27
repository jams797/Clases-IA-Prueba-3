using System;
using System.Collections.Generic;

namespace ConexionDB.Models;

public partial class Sucursal
{
    public int SucursalId { get; set; }

    public string? SucursalNombre { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public int? CiudadId { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
