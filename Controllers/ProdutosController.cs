using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRODUTOSTORE.Data;
using PRODUTOSTORE.Models;
using System;
using System.Linq;

namespace PRODUTOSTORE.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationContext _context;

        public ProdutosController(ApplicationContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Produtos = _context.tblProduto.Include(p => p.Categoria).ToList();
            produtoViewModel.Categorias = _context.tblCategoriaProduto.ToList();

            return View(produtoViewModel);
        }

        [HttpPost]
        public IActionResult CreateOuEdit(ProdutoViewModel produtoViewModel)
        {

            var produto = new Produto();
            produto.Id = produtoViewModel.Id;
            produto.Nome = produtoViewModel.Nome;
            produto.Descricao = produtoViewModel.Descricao;
            produto.CategoriaID = produtoViewModel.CategoriaID;
            produto.Ativo = produtoViewModel.Ativo;
            produto.Perecivel = produtoViewModel.Perecivel;

            if (produtoViewModel.Id > 0)
            {
                _context.tblProduto.Update(produto);
            }
            else
            {
                _context.tblProduto.Add(produto);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _context.tblProduto.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            var produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Id = produto.Id;
            produtoViewModel.Nome = produto.Nome;
            produtoViewModel.Descricao = produto.Descricao;
            produtoViewModel.Ativo = produto.Ativo;
            produtoViewModel.CategoriaID = produto.CategoriaID;
            produtoViewModel.Perecivel = produto.Perecivel;
            produtoViewModel.Categorias = _context.tblCategoriaProduto.ToList();
            produtoViewModel.Produtos = _context.tblProduto.ToList();
            return View("Index", produtoViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _context.tblProduto.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.tblProduto.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
