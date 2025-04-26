using Microsoft.AspNetCore.Mvc;
using Parcial_Delgado.Models;


public class EquiposController : Controller
{
    private readonly AppDbContext _context;

    public EquiposController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View(_context.Equipos.ToList());

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Equipo equipo)
    {
        if (ModelState.IsValid)
        {
            _context.Equipos.Add(equipo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(equipo);
    }
}
