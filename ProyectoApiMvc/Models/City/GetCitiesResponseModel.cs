using System;

namespace ProyectoApiMvc.Models.City;

public class GetCitiesResponseModel
{
    public string name {get; set;}
    public bool isActive {get; set;}
    public DateTime? dateCreate {get; set;}
}
