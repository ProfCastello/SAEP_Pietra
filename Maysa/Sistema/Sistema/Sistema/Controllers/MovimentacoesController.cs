using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema.Data;
using Sistema.Models;

namespace Sistema.Controllers
{
    [Authorize]
    public class MovimentacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovimentacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movimentacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Movimentacoes.Include(m => m.Material).Include(m => m.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movimentacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.Material)
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.MovimentacaoId == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacoes/Create
        public IActionResult Create()
        {
            ViewData["MaterialId"] = new SelectList(_context.Materiais, "MaterialId", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Movimentacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovimentacaoId,MaterialId,UsuarioId,Quantidade,Tipo,DataMovimentacao")] Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                var material = _context.Materiais.Where(p => p.MaterialId == movimentacao.MaterialId).FirstOrDefault();

                if (movimentacao.Tipo == "E")
                {
                    material.EstoqueAtual += movimentacao.Quantidade;
                }
                else if (movimentacao.Tipo == "S")
                {
                    material.EstoqueAtual -= movimentacao.Quantidade;
                }
                if (material.EstoqueAtual <= material.EstoqueMinimo)
                {
                    TempData["Alerta"] = "Atenção: Estoque do material " + material.Nome + " está abaixo do mínimo!";
                }

                if (material.DataValidade <= DateTime.Now.AddDays(5))
                {
                    TempData["Alerta"] = "Atenção: O material " + material.Nome + " está próximo da validade!";
                }

                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialId"] = new SelectList(_context.Materiais, "MaterialId", "Nome", movimentacao.MaterialId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Email", movimentacao.UsuarioId);
            return View(movimentacao);
        }

        // GET: Movimentacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["MaterialId"] = new SelectList(_context.Materiais, "MaterialId", "Nome", movimentacao.MaterialId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Email", movimentacao.UsuarioId);
            return View(movimentacao);
        }

        // POST: Movimentacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovimentacaoId,MaterialId,UsuarioId,Quantidade,Tipo,DataMovimentacao")] Movimentacao movimentacao)
        {
            if (id != movimentacao.MovimentacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoExists(movimentacao.MovimentacaoId))
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
            ViewData["MaterialId"] = new SelectList(_context.Materiais, "MaterialId", "Nome", movimentacao.MaterialId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Email", movimentacao.UsuarioId);
            return View(movimentacao);
        }

        // GET: Movimentacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.Material)
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.MovimentacaoId == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao != null)
            {
                _context.Movimentacoes.Remove(movimentacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacoes.Any(e => e.MovimentacaoId == id);
        }
    }
}
