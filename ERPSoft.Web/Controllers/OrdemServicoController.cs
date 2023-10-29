using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using ERPSoft.Web.Areas.Identity.Data;
using ERPSoft.Web.Constants;
using ERPSoft.Web.EmailSender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.Web.Controllers
{
    public class OrdemServicoController : Controller
    {
        private readonly IOrdemServico _repositoryOrdemServico;
        private readonly IPedidoServico _repositoryPedidoServico;
        private readonly IFornecedor _repositoryFornecedor;
        private readonly UserManager<Usuario> _userManager;
        public OrdemServicoController(IOrdemServico repositoryOrdemServico, IPedidoServico repositoryPedidoServico, IFornecedor repositoryFornecedor, UserManager<Usuario> userManager)
        {
            _repositoryOrdemServico = repositoryOrdemServico;
            _repositoryPedidoServico = repositoryPedidoServico;
            _repositoryFornecedor = repositoryFornecedor;
            _userManager = userManager;
        }

        //--------- Create
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Create()
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;

            var pedidoServicos = _repositoryPedidoServico.GetAll();
            ViewBag.PedidoServico = pedidoServicos;

            return View();
        }

        [HttpPost]
        public IActionResult Create(OrdemServico ordemServico)
        {

            Random random = new Random();
            int numeroAleatorio = random.Next(1, 10000);

            if (ModelState.IsValid)
            {
                var fornercedor = _repositoryFornecedor.GetById(ordemServico.IdOrdemFornecedor);
                var enviarEmail = new Email("smtp.office365.com", "erpsoftsystem@outlook.com", "ErpSoft01");
                enviarEmail.EnviarEmail(fornercedor.Email, "Demanda de Serviço", $"Olá {fornercedor.Nome}! Gostariamos de comunicar a existencia da demande de serviços internos em nosso empresa e nós temos interesse em uma parceria! \n" +
                    $" aqui estão algumas informações: \n Valor do Serviço: {ordemServico.Total}");
                ordemServico.Ordem += numeroAleatorio;
                ordemServico.DataCadastro = DateTime.Now;
                

                _repositoryOrdemServico.Create(ordemServico);
                var pedidoServico = _repositoryPedidoServico.GetById(ordemServico.IdOrdemPedidoServico);
                if (pedidoServico != null)
                {
                    pedidoServico.StatusServico = "Conferencia";
                    _repositoryPedidoServico.Update(pedidoServico);
                }

                ordemServico.NomeServico = pedidoServico.NomeServico;

                return RedirectToAction("Index");
            }
            else
            {
                return View(ordemServico);
            }
        }

        //--------- Read
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Index()
        {
            var ordensServico = _repositoryOrdemServico.GetAll();
            foreach (var ordemServico in ordensServico)
            {
                if (ordemServico.IdOrdemFornecedor != null)
                {
                    var fornecedor = _repositoryFornecedor.GetById(ordemServico.IdOrdemFornecedor);
                    ordemServico.NomeFornecedor = fornecedor?.Nome;
                    ordemServico.DataFormatada = ordemServico.DataCadastro.ToString("dd/MM/yyyy");
                }

                if (ordemServico.IdOrdemPedidoServico != null)
                {
                    var pedidoServico = _repositoryPedidoServico.GetById(ordemServico.IdOrdemPedidoServico);
                    ordemServico.NomeServico = pedidoServico.NomeServico;
                    ordemServico.DataFormatada = ordemServico.DataCadastro.ToString("dd/MM/yyyy");
                }
            }

            return View(ordensServico);
        }

        //--------- Delete
        [Authorize(Roles = Roles.Usuario)]
        public IActionResult Delete(int id)
        {
            _repositoryOrdemServico.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
