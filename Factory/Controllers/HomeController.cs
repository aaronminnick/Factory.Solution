using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;

    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Engineers = _db.Engineers
        .Include(engineer => engineer.Licenses)
        .ToList();
      ViewBag.Machines = _db.Machines
        .Include(machine => machine.Licenses)
        .ToList();
      return View();
    }
  }
}