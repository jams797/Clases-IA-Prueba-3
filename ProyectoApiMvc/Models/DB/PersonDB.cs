using System;
using System.Collections.Generic;

namespace ProyectoApiMvc.Models.DB;

public partial class PersonDB
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public double Salary { get; set; }

    public double Input { get; set; }

    public virtual ICollection<PetDB> Pets { get; set; } = new List<PetDB>();
}
