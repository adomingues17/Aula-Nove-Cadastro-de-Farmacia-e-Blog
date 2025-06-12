using Farmacia.Data;
using Farmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Farmacia.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly AppDbContext _db;
        public PharmacyController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Pharmacies.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pharmacy obj)
        {
            if (obj.Nome == obj.Id.ToString())
            {
                ModelState.AddModelError("Nome", "Não podem ser iguais.");
            }

            if (ModelState.IsValid)
            {
                _db.Pharmacies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Cadastro realizado com sucesso.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Pharmacy categoryFromDb = _db.Pharmacies.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Pharmacy obj)
        {
            if (ModelState.IsValid)
            {
                _db.Pharmacies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Cadastro atualizado com sucesso.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Pharmacy categoryFromDb = _db.Pharmacies.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Pharmacy obj = _db.Pharmacies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Pharmacies.Remove(obj);
            _db.SaveChanges();
            TempData["error"] = "Registro excluido com sucesso.";
            return RedirectToAction("Index");
        }
    }
}
