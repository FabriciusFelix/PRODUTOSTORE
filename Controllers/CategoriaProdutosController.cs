using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRODUTOSTORE.Data;
using PRODUTOSTORE.Models;

namespace PRODUTOSTORE.Controllers
{
    public class CategoriaProdutosController : Controller
    {
        private readonly ApplicationContext _context;

        public CategoriaProdutosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: CategoriaProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblCategoriaProduto.ToListAsync());
        }

        // GET: CategoriaProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.tblCategoriaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }

            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Ativo")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.tblCategoriaProduto.FindAsync(id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }
            return View(categoriaProduto);
        }

        // POST: CategoriaProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Ativo")] CategoriaProduto categoriaProduto)
        {
            if (id != categoriaProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProdutoExists(categoriaProduto.Id))
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
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.tblCategoriaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }

            return View(categoriaProduto);
        }

        // POST: CategoriaProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaProduto = await _context.tblCategoriaProduto.FindAsync(id);
            _context.tblCategoriaProduto.Remove(categoriaProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProdutoExists(int id)
        {
            return _context.tblCategoriaProduto.Any(e => e.Id == id);
        }
    }
}
