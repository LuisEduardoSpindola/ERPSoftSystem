using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using ERPSoft.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.Web.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServico _repositoryServico;
        private readonly IFornecedor _repositoryFornecedor;
        public ServicoController(IServico repositoryServico, IFornecedor repositoryFornecedor) 
        {
            _repositoryServico = repositoryServico;
            _repositoryFornecedor = repositoryFornecedor; 
        }

        //--------- Create

        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Create()
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores; 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Servicos servico)
        {
            if (ModelState.IsValid) 
            {
                var DataFormatada = servico.Data.ToString("dd/MM/yyyy");
                _repositoryServico.Create(servico);
                return RedirectToAction("Index");
            }else 
            {
                return View(servico);
            }
        }

        //--------- Read

        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Index()
        {
            var servicos = _repositoryServico.GetAll();
            foreach (var servico in servicos)
            {
                if (servico.IdFornecedor != null)
                {
                    var fornecedor = _repositoryFornecedor.GetById(servico.IdFornecedor);
                    servico.NomeFornecedor = fornecedor?.Nome; 
                }
            }

            return View(servicos);
        }


        //--------- Update

        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Edit(int id)
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;
            var servico = _repositoryServico.GetById(id);
            return View(servico);
        }

        [HttpPost]
        public IActionResult Edit(Servicos servico)
        {
            _repositoryServico.Update(servico);
            return RedirectToAction("Index");
        }

    }
}
