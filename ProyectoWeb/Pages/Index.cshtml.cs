using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
}

