using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Controllers
{
  public class PetsCollectionController : Controller
  {
    private readonly InventoryContext _db;

    public PetsCollectionController(InventoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<PetsCollection> model = _db.PetsCollections.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(PetsCollection petsCollection)
    {
      _db.PetsCollection.Add(petsCollection);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      PetsCollection thisPetsCollection = _db.PetsCollections.FirstOrDefault(petsCollection => petsCollection.PetsCollectionId == id);
      return View(thisPetsCollection);
    }

    public ActionResult Edit(int id)
    {
      var thisPetsCollection = _db.PetsCollections.FirstOrDefault(petsCollection => petCollection.PetsCollectionId == id);
      return View(thisPetsCollection);
    }

    [HttpPost]
    public ActionResult Edit(PetsCollection petsCollection)
    {
      _db.Entry(petsCollection).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPetsCollection = _db.PetsCollections.FirstOrDefault(petsCollection => petsCollection.PetsCollectionId == id);
      return View(thisPetsCollection);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPetsCollection = _db.PetsCollections.FirstOrDefault(petsCollection => petsCollection.PetsCollectionId == id);
      _db.Collections.Remove(thisPetsCollection);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}