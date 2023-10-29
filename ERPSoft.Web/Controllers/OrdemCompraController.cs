using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using ERPSoft.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPSoft.Web.EmailSender;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using ERPSoft.DATA.Migrations;

namespace ERPSoft.Web.Controllers
{
    public class OrdemCompraController : Controller
    {
        private readonly IOrdemCompra _repositoryOrdemCompra;
        private readonly IPedidoMaterial _repositoryPedidoMaterial;
        private readonly IFornecedor _repositoryFornecedor;
        private readonly UserManager<Usuario> _userManager;
        public OrdemCompraController(IOrdemCompra repositoryOrdemCompra, IPedidoMaterial repositoryPedidoMaterial, IFornecedor repositoryFornecedor, UserManager<Usuario> userManager)
        {
            _repositoryOrdemCompra = repositoryOrdemCompra;
            _repositoryPedidoMaterial = repositoryPedidoMaterial;
            _repositoryFornecedor = repositoryFornecedor;
            _userManager = userManager;
        }

        //--------- Create

        public IActionResult Create()
        {
            var fornecedores = _repositoryFornecedor.GetAll();
            ViewBag.Fornecedores = fornecedores;

            var pedidoMateriais = _repositoryPedidoMaterial.GetAll(); 
            ViewBag.PedidoMaterial = pedidoMateriais;

            return View();
        }

        [HttpPost]
        public IActionResult Create(OrdemCompra ordemCompra)
        {

            Random random = new Random();
            int numeroAleatorio = random.Next(1, 10000);

            if (ModelState.IsValid)
            {
                var fornercedor = _repositoryFornecedor.GetById(ordemCompra.IdOrdemFornecedor);
                var enviarEmail = new Email("smtp.office365.com", "erpsoftsystem@outlook.com", "ErpSoft01");
                enviarEmail.EnviarEmail(fornercedor.Email, "Oportunidade de Negócio B2B!", $"Olá {fornercedor.Nome}! Temos uma demanda de materias internos e gostariamos de negociar com sua empresa. Tem interesse? \n" +
                    $" aqui estão algumas informações: \n Quantidade: {ordemCompra.Qtda} \n Valor: {ordemCompra.Valor}");
                ordemCompra.Ordem += numeroAleatorio;
                ordemCompra.DataCadastro = DateTime.Now;
                ordemCompra.Total = ordemCompra.Qtda * ordemCompra.Valor;

                _repositoryOrdemCompra.Create(ordemCompra);
                var pedidoMaterial = _repositoryPedidoMaterial.GetById(ordemCompra.IdOrdemPedidoMaterial);
                if (pedidoMaterial != null)
                {
                    pedidoMaterial.StatusMaterial = "Conferencia";
                    _repositoryPedidoMaterial.Update(pedidoMaterial);
                }

                

                return RedirectToAction("Index");
            }
            else
            {
                return View(ordemCompra);
            }
        }

        //--------- Read

        public IActionResult Index()
        {
            var ordensCompra = _repositoryOrdemCompra.GetAll();
            foreach (var ordemCompra in ordensCompra)
            {
                if (ordemCompra.IdOrdemFornecedor != null)
                {
                    var fornecedor = _repositoryFornecedor.GetById(ordemCompra.IdOrdemFornecedor);
                    ordemCompra.NomeFornecedor = fornecedor?.Nome;
                    ordemCompra.DataFormatada = ordemCompra.DataCadastro.ToString("dd/MM/yyyy");
                }

                if (ordemCompra.IdOrdemPedidoMaterial != null)
                {
                    var pedidoMaterial = _repositoryPedidoMaterial.GetById(ordemCompra.IdOrdemPedidoMaterial);
                    ordemCompra.DataFormatada = ordemCompra.DataCadastro.ToString("dd/MM/yyyy");
                }
            }

            return View(ordensCompra);
        }

        //--------- Delete

        public IActionResult Delete(int id)
        {
            _repositoryOrdemCompra.DeleteById(id);
            return RedirectToAction("Index");
        }

        //---- Sende Email

        //public IActionResult SendEmail(string Email)
        //{
        //    try
        //    {
        //        var enviarEmail = new EnviarEmail(Email);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorMessage = "Ocorreu um erro ao enviar o e-mail: " + ex.Message;
        //        return View("Error");
        //    }
        //}

    }
}
