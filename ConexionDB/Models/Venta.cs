using System;
using System.Collections.Generic;

namespace ConexionDB.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    public int? FacturaId { get; set; }

    public string? NumFact { get; set; }

    public DateTime? FechaHora { get; set; }

    public int? ClienteId { get; set; }

    public int? ProductoId { get; set; }

    public int? SucursalId { get; set; }

    public int? CajaId { get; set; }

    public int? VendedorId { get; set; }

    public decimal? Precio { get; set; }

    public int? Unidades { get; set; }

    public int? Estado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Sucursal? Sucursal { get; set; }
}
