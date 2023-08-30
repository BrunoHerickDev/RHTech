﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RhTech.Core.Domain.Entities;
using RHTech.Infra.Data;

namespace RhTech.WebApplication.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly RhTechDbContext _context;

        public CandidatosController(RhTechDbContext context)
        {
            _context = context;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
              return _context.Candidatos != null ? 
                          View(await _context.Candidatos.ToListAsync()) :
                          Problem("Entity set 'RhTechDbContext.Candidatos'  is null.");
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,Cpf,DataNascimento,Genero,Nacionalidade")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,Cpf,DataNascimento,Genero,Nacionalidade")] Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.Id))
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
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidatos == null)
            {
                return Problem("Entity set 'RhTechDbContext.Candidatos'  is null.");
            }
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato != null)
            {
                _context.Candidatos.Remove(candidato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
          return (_context.Candidatos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
