
using ProyectoWeb.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
    public string Uuid { get; set; } = string.Empty;
    [BindProperty]
    [Required(ErrorMessage = "El nombre es requerido"), StringLength(50, MinimumLength = 4, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
    public string Name { get; set; } = string.Empty;
    [BindProperty]
    public int Age { get; set; }
    [BindProperty]
    public double Salary { get; set; }

    // Get
    // Post
    // Put
    // Delete

    public IActionResult OnPostCreate()
    {
        //if (!ModelState.IsValid())
        //{
        //    return Page();
        //}
        // if((uuid ?? "") != "")
        // {
        //     PersonModel personEdit = ListPersons.First((person) => person.id == uuid);
        //     personEdit.UpdateSalary(Salary);
        // } else
        // {
        //     ListPersons.Add(new PersonModel(Name, Age, Salary));
        // }
        ListPersons.Add(new PersonModel(Name, Age, Salary));
        return Page();
    }


    public IActionResult OnPostEdit(string id)
    {
        //if (!ModelState.IsValid())
        //{
        //    return Page();
        //}
        PersonModel personEdit = ListPersons.First((person) => person.id == id);
        personEdit.UpdateSalary(Salary);
        return Page();
    }

    public IActionResult OnPostDelete(string id)
    {
        // if(ModelState.IsValid == false)
        // {
        //     return Page();
        // }

        ListPersons.RemoveAll((person) => person.id == id);

        return Page();
    }
}

