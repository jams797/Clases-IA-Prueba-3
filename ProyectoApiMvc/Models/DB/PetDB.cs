using System;
using System.Collections.Generic;

namespace ProyectoApiMvc.Models.DB;

public partial class PetDB
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int PersonId { get; set; }

    public virtual PersonDB Person { get; set; } = null!;
}
