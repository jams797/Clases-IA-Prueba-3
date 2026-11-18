using ProyectoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

List<Library.Models.PersonModel> persons = new List<Library.Models.PersonModel>
{
    new Library.Models.PersonModel("Juan", 30, 1000.0),
    new Library.Models.PersonModel("Pedro", 25, 1500.0),
    new Library.Models.PersonModel("Maria", 28, 2000.0),
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Jose", "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return new ResponseModel<WeatherForecast[]> { message = "Datos obtenidos correctamente", data = forecast, code = 200 };
})
.WithName("GetWeatherForecast")
.WithOpenApi();


app.MapGet("/GetPersons", () =>
{
    
    return new ResponseModel<List<Library.Models.PersonModel>> { message = "Personas obtenidas correctamente", data = persons, code = 200 };
})
.WithName("GetPersons")
.WithOpenApi();

app.MapPost("/SavePerson", (AddPersonModel person) =>
{
    if(persons.Exists((personList) => personList.name == person.name))
    {
        return new ResponseModel<string?> { message = "La persona ya existe", code = 400, data = null };
    }
    persons.Add(new Library.Models.PersonModel(person.name, person.age, person.salary));
    return new ResponseModel<string?> { message = "Persona guardada correctamente", code = 200, data = null };
})
.WithName("SavePerson")
.WithOpenApi();


app.MapPut("/UpdateSalaryPerson/{id}", (string id, GetParamSalaryModel person) =>
{
    var personToUpdate = persons.Find((personList) => personList.id == id);
    if(personToUpdate == null)
    {
        return new ResponseModel<string?> { message = "La persona no existe", code = 400, data = null };
    }
    personToUpdate.UpdateSalary(person.salary);
    return new ResponseModel<string?> { message = "Salario actualizado correctamente", code = 200, data = null };
})
.WithName("UpdateSalaryPerson")
.WithOpenApi();

app.MapDelete("/DeletePerson/{id}", (string id) =>
{
    var personToUpdate = persons.Find((personList) => personList.id == id);
    if(personToUpdate == null)
    {
        return new ResponseModel<string?> { message = "La persona no existe", code = 400, data = null };
    }
    persons.Remove(personToUpdate);
    return new ResponseModel<string?> { message = "Persona eliminada correctamente", code = 200, data = null };
})
.WithName("DeletePerson")
.WithOpenApi();



app.MapPost("/GetPersonsFilterBySalary", (GetParamSalaryModel paramsModel) =>
{
    
    return new ResponseModel<List<Library.Models.PersonModel>> { message = "Personas obtenidas correctamente", data = persons.Where((person) => person.salary >= paramsModel.salary).ToList(), code = 200 };
})
.WithName("GetPersonsFilterBySalary")
.WithOpenApi();

// Crear un servicio que me permita editar el salario de las personas (por id)
// Crear un servicio que me permita eliminar una persona por su id
// Crear un servicio que me permita obtener las personas que tengan un salario mayor a un valor ingresado por el usuario

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
