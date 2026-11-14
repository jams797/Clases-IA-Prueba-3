
using ProyectoWeb.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Pages;

public class IndexModel : PageModel
{

    public static List<PersonModel> ListPersons = new List<PersonModel>()
    {
        new PersonModel("Jose", 22, 400),
        new PersonModel("Pepe", 30, 700)
    };
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    [BindProperty]
    public PersonModelCreate Formulario { get; set; } = new();

    public IActionResult OnPostCreate()
    {
        string? name = Request.Form["name"];
        int? age = int.Parse(Request.Form["age"]);
        double? salary = double.Parse(Request.Form["salary"]);
        //if (!ModelState.IsValid())
        //{
        //    return Page();
        //}
        string? uuid = Request.Form["uuid"];
        if((uuid ?? "") != "")
        {
            PersonModel personEdit = ListPersons.First((person) => person.id == uuid);
            personEdit.UpdateSalary(salary ?? 0);
        } else
        {
            ListPersons.Add(new PersonModel(name, age ?? 0, salary ?? 0));
        }
        return Page();
    }

    public IActionResult OnPostDelete()
    {
        string? uuid = Request.Form["id"];

        ListPersons.RemoveAll((person) => person.id == uuid);

        return Page();
    }
}

