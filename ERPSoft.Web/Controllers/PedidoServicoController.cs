using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using ERPSoft.Web.Areas.Identity.Data;
using ERPSoft.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.Web.Controllers
{
    public class PedidoServicoController : Controller
    {
        private readonly IPedidoServico _repositoryPedidoServico;
        private readonly IServico _repositoryServico;
        private readonly IFornecedor _repositoryFornecedor;
        private readonly UserManager<Usuario> _userManager;
        public PedidoServicoController(IPedidoServico repositoryPedidoServico, IServico repositoryServico, IFornecedor repositoryFornecedor, UserManager<Usuario> userManager)
        {
            _repositoryPedidoServico = repositoryPedidoServico;
            _repositoryServico = repositoryServico;
            _repositoryFornecedor = repositoryFornecedor;
            _userManager = userManager;
        }

        //--------- Create

        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Create()
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;

            var servicos = _repositoryServico.GetAll(); 
            ViewBag.Servicos = servicos;

            return View();
        }

        [HttpPost]
        public IActionResult Create(PedidoServico pedidoServico)
        {

            Random random = new Random();
            int numeroAleatorio = random.Next(1, 10000);

            if (ModelState.IsValid)
            {
                pedidoServico.Cod += numeroAleatorio;
                pedidoServico.Usuario = _userManager.GetUserAsync(User).Result.Nome;
                pedidoServico.Departamento = _userManager.GetUserAsync(User).Result.Departamento;
                pedidoServico.DataCadastro = DateTime.Now;


                _repositoryPedidoServico.Create(pedidoServico);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pedidoServico);
            }
        }

        //--------- Read

        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Index()
        {
            var pedidoMateriais = _repositoryPedidoServico.GetAll();
            foreach (var pedidoServico in pedidoMateriais)
            {
                if (pedidoServico.IdPedidoSfornecedor != null)
                {
                    var fornecedor = _repositoryFornecedor.GetById(pedidoServico.IdPedidoSfornecedor);
                    pedidoServico.NomeFornecedor = fornecedor?.Nome;
                    pedidoServico.DataFormatada = pedidoServico.DataCadastro.ToString("dd/MM/yyyy");
                }

                if (pedidoServico.IdPedidoSservico != null)
                {
                    var servico = _repositoryServico.GetById(pedidoServico.IdPedidoSservico);
                    pedidoServico.NomeServico = servico?.Nome;
                    pedidoServico.DataFormatada = pedidoServico.DataCadastro.ToString("dd/MM/yyyy");
                }
            }

            return View(pedidoMateriais);
        }

        //--------- Update
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Edit(int id)
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;

            var servicos = _repositoryServico.GetAll();
            ViewBag.Servicos = servicos;

            var pedidoServico = _repositoryPedidoServico.GetById(id);
            return View(pedidoServico);
        }

        [HttpPost]
        public IActionResult Edit(PedidoServico pedidoServico)
        {
            if (ModelState.IsValid)
            {
                pedidoServico.Usuario = _userManager.GetUserAsync(User).Result.Nome;
                pedidoServico.Departamento = _userManager.GetUserAsync(User).Result.Departamento;
                pedidoServico.DataCadastro = DateTime.Now;

                _repositoryPedidoServico.Update(pedidoServico);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pedidoServico);
            }
        }

        //--------- Delete
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Delete(int id)
        {
            _repositoryPedidoServico.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
