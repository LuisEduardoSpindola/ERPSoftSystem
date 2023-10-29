using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.Web.Controllers
{
    public class EntradaController : Controller
    {
        private readonly IEntrada _repositoryEntrada;
        private readonly IProduto _repositoryProduto;
        private readonly IFornecedor _repositoryFornecedor;
        public EntradaController(IEntrada repositoryEntrada, IProduto repositoryProduto, IFornecedor repositoryFornecedor)
        {
            _repositoryEntrada = repositoryEntrada;
            _repositoryProduto = repositoryProduto;
            _repositoryFornecedor = repositoryFornecedor;
        }

        //--------- Create

        public IActionResult Create()
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;

            var produtos = _repositoryProduto.GetAll();
            ViewBag.Produtos = produtos;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _repositoryEntrada.Create(entrada);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entrada);
            }
        }

        //--------- Read

        public IActionResult Index()
        {
            var entradas = _repositoryEntrada.GetAll();
            foreach (var entrada in entradas)
            {
                if (entrada.IdEntradaFornecedor != null)
                {
                    var fornecedor = _repositoryFornecedor.GetById(entrada.IdEntradaFornecedor);
                    entrada.NomeFornecedor = fornecedor?.Nome;
                    entrada.DataFormatada = entrada.DataCadastro.ToString("dd/MM/yyyy");
                }

                if (entrada.IdEntradaProduto != null)
                {
                    var produto = _repositoryProduto.GetById(entrada.IdEntradaProduto);
                    entrada.NomeProduto = produto?.Nome;
                    entrada.DataFormatada = entrada.DataCadastro.ToString("dd/MM/yyyy");
                }
            }

            return View(entradas);
        }


        //--------- Update

        public ActionResult Edit(int id)
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;

            var produtos = _repositoryProduto.GetAll();
            ViewBag.Produtos = produtos;


            var servico = _repositoryEntrada.GetById(id);
            return View(servico);
        }

        [HttpPost]
        public IActionResult Edit(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _repositoryEntrada.Update(entrada);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entrada);
            }
        }

        //--------- Delete

        public IActionResult Delete(int id)
        {
            _repositoryEntrada.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
