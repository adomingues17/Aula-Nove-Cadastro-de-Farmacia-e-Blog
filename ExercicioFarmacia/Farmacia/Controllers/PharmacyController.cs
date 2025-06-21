using Farmacia.Data;
using Farmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Farmacia.Controllers;

public class PharmacyController : Controller
{
    private readonly AppDbContext _db;
    public PharmacyController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index(string busca, int pagina = 1, int tamanhoPagina = 4)
    {
        var query = _db.Pharmacies.AsQueryable();

        if (!string.IsNullOrEmpty(busca))        
            query = query.Where(c => c.Nome.Contains(busca));

        int totalRegistros = query.Count();
        var farmacias = query
            .OrderBy(c => c.Nome)
            .Skip((pagina - 1)*tamanhoPagina)
            .Take(tamanhoPagina)
            .ToList();

        ViewBag.TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamanhoPagina);
        ViewBag.PaginaAtual = pagina;
        ViewBag.Busca = busca;

        return View(farmacias);
      
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Pharmacy obj)
    {
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

        Pharmacy pharmacyFromDb = _db.Pharmacies.Find(id);
        if (pharmacyFromDb == null)
        {
            return NotFound();
        }
        return View(pharmacyFromDb);
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

        Pharmacy pharmacyFromDb = _db.Pharmacies.Find(id);

        if (pharmacyFromDb == null)
        {
            return NotFound();
        }
        return View(pharmacyFromDb);
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
