using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Details(int id)
    {
      Machine model = _db.Machines
        .Include(machine => machine.Licenses)
        .FirstOrDefault(machine => machine.MachineId == id);
      ViewData["Engineers"] = _db.Engineers.ToList();
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = machine.MachineId});
    }

    [HttpPost("Machines/AddLicense")]
    public PartialViewResult AddLicense(int EngineerId, int MachineId)
    {
      _db.Licenses.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = MachineId});
      _db.SaveChanges();
      Machine model = _db.Machines
        .Include(machine => machine.Licenses)
        .FirstOrDefault(machine => machine.MachineId == MachineId);
      ViewData["Engineers"] = _db.Engineers.ToList();
      return PartialView("_ManageLicensesPartial", model);
    }

    [HttpPost("Machines/RemoveLicense")]
    public PartialViewResult RemoveLicense(int EngineerId, int MachineId)
    {
      EngineerMachine license = _db.Licenses.FirstOrDefault(license => license.EngineerId == EngineerId && license.MachineId == MachineId);
      _db.Licenses.Remove(license);
      _db.SaveChanges();
      Machine model = _db.Machines
        .Include(machine => machine.Licenses)
        .FirstOrDefault(machine => machine.MachineId == MachineId);
      ViewData["Engineers"] = _db.Engineers.ToList();
      return PartialView("_ManageLicensesPartial", model);
    }

    [HttpPost]
    public ActionResult Delete(int MachineId)
    {
      Machine machine = _db.Machines.FirstOrDefault(machine => machine.MachineId == MachineId);
      _db.Machines.Remove(machine);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}