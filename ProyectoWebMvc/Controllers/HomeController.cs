using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoWebMvc.Models;

namespace ProyectoWebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(VarsHelper.persons);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AddUser(PersonModelCreate person)
    {
        if(!ModelState.IsValid)
        {
            return View("Index", VarsHelper.persons);
        }
        VarsHelper.persons.Add(new Library.Models.PersonModel(person.Name, person.Age, person.Salary));
        return RedirectToAction("Index");
    }

    public IActionResult EditUser(string id, PersonModelEditSalary person)
    {
        if(!ModelState.IsValid)
        {
            return View("Index", VarsHelper.persons);
        }
        VarsHelper.persons.FirstOrDefault(p => p.id == id).UpdateSalary(double.Parse(person.Salary));
        return RedirectToAction("Index");
    }

    public IActionResult DeleteUser(string id)
    {
        VarsHelper.persons.Remove(VarsHelper.persons.FirstOrDefault(p => p.id == id));
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
