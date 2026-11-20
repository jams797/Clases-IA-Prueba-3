using System;

namespace ProyectoApiMvc.Models.Persons;

public class GetPersonRespModel
{
    public int id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public double salary { get; set; }
    public double input { get; set; }
}
