using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using ERPSoft.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Globalization;

namespace ERPSoft.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProduto _repositoryProduto;

        public ProdutoController(IProduto repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }

        //--------- Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (!ModelState.IsValid) 
            {
                return View(produto);
            }else 
            {
                if (produto.EstoqueMin >= produto.EstoqueIdeal)
                {
                    ModelState.AddModelError(string.Empty, "O estoque mínimo não pode ser maior ou igual ao estoque ideal.");
                    return View(produto);
                }
                produto.PrecoTotal = produto.EstoqueAtual * produto.Preco;
                _repositoryProduto.Create(produto);
                return RedirectToAction("Index");
            }
        }

        //--------- Read

        //[Authorize(Roles = Roles.Usuario)]
        public IActionResult Index()
        {
            var produtos = _repositoryProduto.GetAll();
            return View(produtos);
        }

        //--------- Update

        public ActionResult Edit(int id)
        {
            var produto = _repositoryProduto.GetById(id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid) 
            {
                _repositoryProduto.Update(produto);
                return RedirectToAction("Index");
            }
            else 
            {
                return View(produto);
            }
        }

        //--------- Delete

        public IActionResult Delete(int id)
        {
            _repositoryProduto.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
