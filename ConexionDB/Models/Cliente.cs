using System;
using System.Collections.Generic;

namespace ConexionDB.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? ClienteNombre { get; set; }

    public string? Cedula { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
