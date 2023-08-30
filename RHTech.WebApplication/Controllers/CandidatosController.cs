using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RhTech.Core.Application.Interfaces;
using RhTech.Core.Application.ViewModels;

namespace RhTech.WebApplication.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly ICandidatosService _candidatosService;

        public CandidatosController(ICandidatosService candidatosService)
        {
            _candidatosService = candidatosService;
        }

        public async Task<IActionResult> Index()
        {
            var candidatos = await _candidatosService.ObterLista();

            return candidatos != null ?
                        View(candidatos) :
                        Problem("Entidade Candidatos é nula");
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var candidato = await _candidatosService.ObterPorId(id.GetValueOrDefault());

            if (candidato == null)
                return NotFound();

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
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,Cpf,DataNascimento,Genero,Nacionalidade")] CandidatoViewModel candidato)
        {
            if (ModelState.IsValid)
            {
                await _candidatosService.Cadastrar(candidato);

                return RedirectToAction(nameof(Index));
            }

            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var candidato = await _candidatosService.ObterPorId(id.GetValueOrDefault());

            if (candidato == null)
                return NotFound();

            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,Cpf,DataNascimento,Genero,Nacionalidade")] CandidatoViewModel candidato)
        {
            if (id != candidato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _candidatosService.Alterar(candidato);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CandidatoExistsAsync(candidato.Id))
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
            if (id == null)
                return NotFound();

            var candidato = await _candidatosService.ObterPorId(id.GetValueOrDefault());

            if (candidato == null)
                return NotFound();


            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _candidatosService.ObterPorId(id);

            if (candidato == null)
            {
                return Problem("Entidade candidato é nula.");
            }

            await _candidatosService.Remover(candidato.Id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CandidatoExistsAsync(int id)
        {
            return await _candidatosService.ObterPorId(id) != null;
        }
    }
}
