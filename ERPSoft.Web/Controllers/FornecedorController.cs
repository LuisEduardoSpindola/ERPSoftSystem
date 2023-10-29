using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using ERPSoft.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERPSoft.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedor _repositoryFornecedor;
        private readonly IServico _repositoryServico;

        public FornecedorController(IFornecedor repositoryFornecedor, IServico repositoryServico)
        {
            _repositoryFornecedor = repositoryFornecedor;
            _repositoryServico = repositoryServico;
        }

        //--------- Create
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fornecedor fornecedor)
        {
            _repositoryFornecedor.Create(fornecedor);
            return RedirectToAction("Index");
        }

        //--------- Read
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Index()
        {
            var fornecedor = _repositoryFornecedor.GetAll();
            return View(fornecedor);
        }

        //--------- Update
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Edit(int id)
        {
            var fornecedor = _repositoryFornecedor.GetById(id);
            return View(fornecedor);
        }

        [HttpPost]
        public IActionResult Edit(Fornecedor fornecedor)
        {
            _repositoryFornecedor.Update(fornecedor);
            return RedirectToAction("Index");
        }

        //--------- Delete

        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Delete(int id)
        {
            _repositoryFornecedor.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
