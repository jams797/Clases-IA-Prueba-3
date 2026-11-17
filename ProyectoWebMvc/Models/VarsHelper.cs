using System;
using Library.Models;

namespace ProyectoWebMvc.Models;

public class VarsHelper
{
    public static List<PersonModel> persons = new List<PersonModel>
    {
        new PersonModel("Juan", 30, 1000.0),
        new PersonModel("Pedro", 25, 1500.0),
        new PersonModel("Maria", 28, 2000.0),
    };
}
