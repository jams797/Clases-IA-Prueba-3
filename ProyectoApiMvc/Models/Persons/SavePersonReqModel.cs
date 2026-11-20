using System;

namespace ProyectoApiMvc.Models.Persons;

public class SavePersonReqModel
{
    public string name { get; set; }
    public int age { get; set; }
    public double salary { get; set; }
}
