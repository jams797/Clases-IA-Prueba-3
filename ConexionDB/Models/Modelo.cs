using System;
using System.Collections.Generic;

namespace ConexionDB.Models;

public partial class Modelo
{
    public int ModeloId { get; set; }

    public string? ModeloDescrip { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
