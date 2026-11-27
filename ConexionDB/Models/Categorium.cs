using System;
using System.Collections.Generic;

namespace ConexionDB.Models;

public partial class Categorium
{
    public int CategId { get; set; }

    public string? CategNombre { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
