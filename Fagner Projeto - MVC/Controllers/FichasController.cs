using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fagner_Projeto___MVC.Models;

namespace Fagner_Projeto___MVC.Controllers
{
    public class FichasController : Controller
    {
        private readonly AppDbContext _context;

        public FichasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Fichas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Fichas.Include(f => f.Exercicio);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Fichas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichaDeTreino = await _context.Fichas
                .Include(f => f.Exercicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fichaDeTreino == null)
            {
                return NotFound();
            }

            return View(fichaDeTreino);
        }

        // GET: Fichas/Create
        public IActionResult Create()
        {
            ViewData["ExercicioId"] = new SelectList(_context.Exercicios, "Id", "Nome");
            return View();
        }

        // POST: Fichas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExercicioId,Repetiçoes,NumeroSerie,TempoDescanso")] FichaDeTreino fichaDeTreino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fichaDeTreino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExercicioId"] = new SelectList(_context.Exercicios, "Id", "Nome", fichaDeTreino.ExercicioId);
            return View(fichaDeTreino);
        }

        // GET: Fichas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichaDeTreino = await _context.Fichas.FindAsync(id);
            if (fichaDeTreino == null)
            {
                return NotFound();
            }
            ViewData["ExercicioId"] = new SelectList(_context.Exercicios, "Id", "Nome", fichaDeTreino.ExercicioId);
            return View(fichaDeTreino);
        }

        // POST: Fichas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExercicioId,Repetiçoes,NumeroSerie,TempoDescanso")] FichaDeTreino fichaDeTreino)
        {
            if (id != fichaDeTreino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fichaDeTreino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaDeTreinoExists(fichaDeTreino.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExercicioId"] = new SelectList(_context.Exercicios, "Id", "Nome", fichaDeTreino.ExercicioId);
            return View(fichaDeTreino);
        }

        // GET: Fichas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichaDeTreino = await _context.Fichas
                .Include(f => f.Exercicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fichaDeTreino == null)
            {
                return NotFound();
            }

            return View(fichaDeTreino);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fichaDeTreino = await _context.Fichas.FindAsync(id);
            if (fichaDeTreino != null)
            {
                _context.Fichas.Remove(fichaDeTreino);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichaDeTreinoExists(int id)
        {
            return _context.Fichas.Any(e => e.Id == id);
        }
    }
}
