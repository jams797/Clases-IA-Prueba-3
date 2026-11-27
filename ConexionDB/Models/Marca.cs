using System;
using System.Collections.Generic;

namespace ConexionDB.Models;

public partial class Marca
{
    public int MarcaId { get; set; }

    public string? MarcaNombre { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
