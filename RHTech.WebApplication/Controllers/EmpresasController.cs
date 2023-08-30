using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RhTech.Core.Application.Interfaces;
using RhTech.Core.Application.ViewModels;

namespace RhTech.WebApplication.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IEmpresasService _empresasService;

        public EmpresasController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
        }

        public async Task<IActionResult> Index()
        {
            var empresas = await _empresasService.ObterLista();

            return empresas != null ?
                        View(empresas) :
                        Problem("Entidade Empresa é nula");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var empresa = await _empresasService.ObterPorId(id.GetValueOrDefault());

            if (empresa == null)
                return NotFound();

            return View(empresa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cnpj,NomeFantasia")] EmpresaViewModel empresa)
        {

            if (ModelState.IsValid)
            {
                await _empresasService.Cadastrar(empresa);

                return RedirectToAction(nameof(Index));
            }

            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var empresa = await _empresasService.ObterPorId(id.GetValueOrDefault());

            if (empresa == null)
                return NotFound();

            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cnpj,NomeFantasia")] EmpresaViewModel empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _empresasService.Alterar(empresa);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await EmpresaExistsAsync(empresa.Id))
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

            return View(empresa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var empresa = await _empresasService.ObterPorId(id.GetValueOrDefault());

            if (empresa == null)
                return NotFound();


            return View(empresa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _empresasService.ObterPorId(id);

            if (empresa == null)
            {
                return Problem("Entidade empresa é nula.");
            }

            await _empresasService.Remover(empresa.Id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EmpresaExistsAsync(int id)
        {
            return await _empresasService.ObterPorId(id) != null;
        }
    }
}
