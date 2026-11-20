using Microsoft.AspNetCore.Mvc;
using ProyectoApiMvc.BD;
using ProyectoApiMvc.Models.DB;
using ProyectoApiMvc.Models.General;
using ProyectoApiMvc.Models.Persons;

namespace ProyectoApiMvc.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    IConfiguration _configuration;
    IResponseGeneralFactory _responseGeneralFactory;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, IResponseGeneralFactory responseGeneralFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _responseGeneralFactory = responseGeneralFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    
    // [HttpGet("api/ServicioPrueba", Name = "ServicioPrueba")]
    [HttpGet("ServicioPrueba", Name = "ServicioPrueba")]
    public string ServicioPrueba()
    {
        // Implementation for getting persons
        return "Servicio de prueba";
    }

    [HttpGet("GetPersonsTmp", Name = "GetPersonsTmp")]
    public ResponseGeneralModel<List<PersonDB>> GetPersonsTmp()
    {
        try{
            using (var context = new ClassContext())
            {
                var persons = context.Persons.ToList();
                return _responseGeneralFactory.Create(
                    true,
                    persons,
                    "Personas obtenidas correctamente",
                    null
                );
            }
        }catch(Exception ex)
        {
            return _responseGeneralFactory.Create<List<PersonDB>>(
                false,
                null,
                "Ocurrio un error al consultar los datos",
                ex.Message
            );
        }
    }

    [HttpPost("SavePerson", Name = "SavePerson")]
    public ResponseGeneralModel<string?> SavePerson(SavePersonReqModel person)
    {
        try{
            using (var context = new ClassContext())
            {
                var personDB = new PersonDB
                {
                    Name = person.name,
                    Age = person.age,
                    Salary = person.salary,
                    Input = (person.salary * 9.11)/100
                };

                context.Persons.Add(personDB);
                context.SaveChanges();
            }
            return _responseGeneralFactory.Create<string?>(
                true,
                "Persona guardada correctamente",
                "Persona guardada correctamente",
                null
            );
        }catch(Exception ex){
            return _responseGeneralFactory.Create<string?>(
                false,
                null,
                "Ocurrio un error al guardar los datos",
                ex.Message
            );
        }
    }

    [HttpGet("GetPersons", Name = "GetPersons")]
    public ResponseGeneralModel<List<GetPersonRespModel>> GetPersons()
    {
        try{
            using (var context = new ClassContext())
            {
                var persons = context.Persons.Select((person) => new GetPersonRespModel
                {
                    id = person.Id,
                    name = person.Name,
                    age = person.Age,
                    salary = person.Salary,
                    input = person.Input
                }).ToList();
                return _responseGeneralFactory.Create(
                    true,
                    persons,
                    "Personas obtenidas correctamente",
                    null
                );
            }
        }catch(Exception ex)
        {
            return _responseGeneralFactory.Create<List<GetPersonRespModel>>(
                false,
                null,
                "Ocurrio un error al consultar los datos",
                ex.Message
            );
        }
    }
}
