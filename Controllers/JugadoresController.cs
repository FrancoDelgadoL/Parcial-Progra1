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
        ViewBag.Equipos = _context.Equipos.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    
    public IActionResult Create([Bind("Nombre,Edad,EquipoId")] Jugador jugador)
    {
        if (ModelState.IsValid)
        {
            _context.Add(jugador);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // Redirige a la lista de jugadores
        }
        return View(jugador);
    }
    
}
