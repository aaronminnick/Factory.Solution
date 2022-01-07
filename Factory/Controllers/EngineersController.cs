using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Details(int id)
    {
      Engineer model = _db.Engineers
        .Include(engineer => engineer.Licenses)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewData["Machines"] = _db.Machines.ToList();
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = engineer.EngineerId});
    }

    [HttpPost("Engineers/AddLicense")]
    public PartialViewResult AddLicense(int EngineerId, int MachineId)
    {
      _db.Licenses.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = MachineId});
      _db.SaveChanges();
      Engineer model = _db.Engineers
        .Include(engineer => engineer.Licenses)
        .FirstOrDefault(engineer => engineer.EngineerId == EngineerId);
      ViewData["Machines"] = _db.Machines.ToList();
      return PartialView("_ManageLicensesPartial", model);
    }

    [HttpPost("Engineers/RemoveLicense")]
    public PartialViewResult RemoveLicense(int EngineerId, int MachineId)
    {
      EngineerMachine license = _db.Licenses.FirstOrDefault(license => license.EngineerId == EngineerId && license.MachineId == MachineId);
      _db.Licenses.Remove(license);
      _db.SaveChanges();
      Engineer model = _db.Engineers
        .Include(engineer => engineer.Licenses)
        .FirstOrDefault(engineer => engineer.EngineerId == EngineerId);
      ViewData["Machines"] = _db.Machines.ToList();
      return PartialView("_ManageLicensesPartial", model);
    }

    [HttpPost]
    public ActionResult Delete(int EngineerId)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == EngineerId);
      _db.Engineers.Remove(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}