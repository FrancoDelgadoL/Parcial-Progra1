using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcial_Delgado.Models;


public class JugadoresController : Controller
{
    private readonly AppDbContext _context;

    public JugadoresController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var jugadores = _context.Jugadores.Include(j => j.Equipo).ToList();
        return View(jugadores);
    }

    public IActionResult Create()
    {
        ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Jugador jugador)
    {
        if (ModelState.IsValid)
        {
            _context.Jugadores.Add(jugador);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Equipos = new SelectList(_context.Equipos, "Id", "Nombre", jugador.EquipoId);
        return View(jugador);
    }
}
