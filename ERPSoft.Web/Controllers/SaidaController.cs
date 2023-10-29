using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.Web.Controllers
{
    public class SaidaController : Controller
    {
        private readonly ISaida _repositorySaida;
        private readonly IProduto _repositoryProduto;
        private readonly IFornecedor _repositoryFornecedor;
        public SaidaController(ISaida repositorySaida, IProduto repositoryProduto, IFornecedor repositoryFornecedor)
        {
            _repositorySaida = repositorySaida;
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
        public IActionResult Create(Saida saida)
        {
            if (ModelState.IsValid)
            {
                _repositorySaida.Create(saida);
                return RedirectToAction("Index");
            }
            else
            {
                return View(saida);
            }
        }

        //--------- Read

        public IActionResult Index()
        {
            var saidas = _repositorySaida.GetAll();
            foreach (var saida in saidas)
            {
                if (saida.IdSaidaProduto != null)
                {
                    var fornecedor = _repositoryProduto.GetById(saida.IdSaidaProduto);
                    saida.NomeProduto = fornecedor?.Nome;
                }

                if (saida.IdSaidaFornecedor != null)
                {
                    var produto = _repositoryFornecedor.GetById(saida.IdSaidaFornecedor);
                    saida.NomeFornecedor = produto?.Nome;
                }
            }

            return View(saidas);
        }


        //--------- Update

        public ActionResult Edit(int id)
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;

            var produtos = _repositoryProduto.GetAll();
            ViewBag.Produtos = produtos;


            var servico = _repositorySaida.GetById(id);
            return View(servico);
        }

        [HttpPost]
        public IActionResult Edit(Saida saida)
        {
            if (ModelState.IsValid)
            {
                _repositorySaida.Update(saida);
                return RedirectToAction("Index");
            }
            else
            {
                return View(saida);
            }
        }

        //--------- Delete

        public IActionResult Delete(int id)
        {
            _repositorySaida.DeleteById(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            var entradas = _repositorySaida.GetAll();
            foreach (var entrada in entradas)
            {
                if (entrada.IdSaidaFornecedor != null)
                {
                    var fornecedor = _repositoryFornecedor.GetById(entrada.IdSaidaFornecedor);
                    entrada.NomeFornecedor = fornecedor?.Nome;
                    entrada.Data.ToString("dd/MM/yyyy");
                }

                if (entrada.IdSaidaProduto != null)
                {
                    var produto = _repositoryProduto.GetById(entrada.IdSaidaProduto);
                    entrada.NomeProduto = produto?.Nome;
                    entrada.DataFormatada = entrada.Data.ToString("dd/MM/yyyy");
                }
            }

            return View(entradas);
        }
    }
}
