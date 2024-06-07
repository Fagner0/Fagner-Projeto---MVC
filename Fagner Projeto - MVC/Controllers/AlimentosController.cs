using Fagner_Projeto___MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Fagner_Projeto___MVC.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly AppDbContext _context;
        public AlimentosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Alimentos.ToListAsync();
            
            return View(dados);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Alimento alimento)
        {
            if (ModelState.IsValid)
            {
                _context.Alimentos.Add(alimento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alimento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                    return NotFound();

            var dados = await _context.Alimentos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Alimento alimento)
        {
            if (id != alimento.Id)
                return NotFound();



            if (ModelState.IsValid)
            {
                _context.Alimentos.Update(alimento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        { 
            if (id == null)
                return NotFound();

            var dados = await _context.Alimentos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados); 
        
        }


    }
}
