using Microsoft.AspNetCore.Http.Features;
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


    [HttpGet(Name = "Prueba")]
    public string? Prueba()
    {
        // ciclado: while - for - foreach
        // condicionales: if-else - switch 
        // operadores: + - * / % == != > < >= <= && || !
        // Listas: List<T> - Colecciones - Array - Dictionary<K,V>

        List<string> lista = new List<string>()
        {
            "Jose", "Maria", "Pedro", "Juan", "Luis"
        };
        // Jose: 0; Maria: 1; Pedro: 2; Juan: 3; Luis: 4

        int indiceB1 = lista.FindIndex((item) => item == "Juan");

        int indiceBusc = -1;
        // int i = 0;
        // foreach(string item in lista)
        // {
        //     if(item == "Juan")
        //     {
        //         indiceBusc = i;
        //         break;
        //     }
        //     i ++;
        // }
        // for(int i = 0; i < lista.Count; i++)
        // {
        //     if(lista[i] == "Juan")
        //     {
        //         indiceBusc = i;
        //         break;
        //     }
        // }
        string? elemento = lista.FirstOrDefault((x) => x == "Juan");

        List<string> listaFiltrada = lista.Where((item) => item.Length > 4).ToList();

        List<PersonaModel> personas = lista.Select((item) => new PersonaModel(item)).ToList();


        List<int> cantidadCaracteres = personas.Select((item) => item.cantidadCaracteres).ToList();

        List<bool> cumplen = lista.Select((item) => item.Length > 4).ToList();
        // false, true, true, false, false

        int edad = int.Parse("30");

        List<int> prueba = lista.Select((item) => int.Parse(item)).ToList();
        List<int> prueba2 = new List<int>();
        foreach(string item in lista)
        {
            prueba2.Add(int.Parse(item));
        }

        lista = lista.Where((item) => item.Length < 5).ToList();
        List<string> lista2 = new List<string>();
        foreach(string item in lista)
        {
            if(item.Length < 5)
            {
                lista2.Add(item);
            }
        }
        lista = lista2;




    return null;
        
    }

    int obtenerDato(string n1)
    {
        return 0;
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

    // Eliminar Persona en base al ID
    // Editar salario de una persona en base a su id

    class PersonaModel
    {
        public string nombre { get; set; }
        public int cantidadCaracteres { get; set; }

        public PersonaModel(string nombre)
        {
            this.nombre = nombre;
            this.cantidadCaracteres = nombre.Length;
        }
    }
}
