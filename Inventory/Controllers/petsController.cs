using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Controllers
{
  public class CollectablesController : Controller
  {
    private readonly InventoryContext _db;

    public CollectablesController(InventoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<petsCollection> model = _db.Pet.Include(pet => collectible.petCollection).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(pet pet)
    {
      _db.pet.Add(pet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      pet thisPet = _db.Pet.FirstOrDefault(pet => pet.PetId == id);
      return View(thisPet);
    }

    public ActionResult Edit(int id)
    {
      var thisPet = _db.Pet.FirstOrDefault(pet => pet.PetId == id);
      return View(thisPet);
    }

    [HttpPost]
    public ActionResult Edit(Pet pet)
    {
      _db.Entry(pet).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPet = _db.Pet.FirstOrDefault(pet => pet.PetId == id);
      return View(thisPet);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPet = _db.Pet.FirstOrDefault(Pet => pet.PetId == id);
      _db.pet.Remove(thisPet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}