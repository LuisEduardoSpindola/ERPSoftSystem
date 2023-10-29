using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using ERPSoft.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.Web.Controllers
{
    public class PedidoMaterialController : Controller
    {
        private readonly IPedidoMaterial _repositoryPedidoMaterial;
        private readonly IProduto _repositoryProduto;
        private readonly UserManager<Usuario> _userManager;
        public PedidoMaterialController(IPedidoMaterial repositoryPedidoMaterial, IProduto repositoryProduto, UserManager<Usuario> userManager)
        {
            _repositoryPedidoMaterial = repositoryPedidoMaterial;
            _repositoryProduto = repositoryProduto;
            _userManager = userManager;
        }

        //--------- Create

        public IActionResult Create()
        {
            var produtos = _repositoryProduto.GetAll();
            ViewBag.Produtos = produtos;

            return View();
        }

        [HttpPost]
        public IActionResult Create(PedidoMaterial pedidoMaterial)
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 10000);

            if (ModelState.IsValid)
            {
                pedidoMaterial.Cod += numeroAleatorio;
                pedidoMaterial.Usuario = _userManager.GetUserAsync(User).Result.Nome;
                pedidoMaterial.Departamento = _userManager.GetUserAsync(User).Result.Departamento;
                pedidoMaterial.DataCadastro =  DateTime.Now;


                _repositoryPedidoMaterial.Create(pedidoMaterial);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pedidoMaterial);
            }
        }

        //--------- Read

        public IActionResult Index()
        {
            var pedidoMateriais = _repositoryPedidoMaterial.GetAll();
            foreach (var pedidoMaterial in pedidoMateriais)
            {
                if (pedidoMaterial.IdPedidoMproduto != null)
                {
                    var produto = _repositoryProduto.GetById(pedidoMaterial.IdPedidoMproduto);
                    pedidoMaterial.NomeProduto = produto?.Nome;
                    pedidoMaterial.DataFormatada = pedidoMaterial.DataCadastro.ToString("dd/MM/yyyy");
                }
            }

            return View(pedidoMateriais);
        }


        //--------- Update

        public IActionResult Edit(int id)
        {
            var produtos = _repositoryProduto.GetAll();
            ViewBag.Produtos = produtos;

            var pedidoMaterial = _repositoryPedidoMaterial.GetById(id);
            return View(pedidoMaterial);
        }

        [HttpPost]
        public IActionResult Edit(PedidoMaterial pedidoMaterial)
        {
            if (ModelState.IsValid)
            {
                pedidoMaterial.Cod = _userManager.GetUserAsync(User).Result.Matricula;
                pedidoMaterial.Usuario = _userManager.GetUserAsync(User).Result.Nome;
                pedidoMaterial.Departamento = _userManager.GetUserAsync(User).Result.Departamento;
                pedidoMaterial.DataCadastro = DateTime.Now;

                _repositoryPedidoMaterial.Update(pedidoMaterial);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pedidoMaterial);
            }
        }

        //--------- Delete

        public IActionResult Delete(int id)
        {
            _repositoryPedidoMaterial.DeleteById(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            var pedidoMateriais = _repositoryPedidoMaterial.GetAll();
            foreach (var pedidoMaterial in pedidoMateriais)
            {
                if (pedidoMaterial.IdPedidoMproduto != null)
                {
                    var produto = _repositoryProduto.GetById(pedidoMaterial.IdPedidoMproduto);
                    pedidoMaterial.NomeProduto = produto?.Nome;
                    pedidoMaterial.DataFormatada = pedidoMaterial.DataCadastro.ToString("dd/MM/yyyy");
                }
            }

            return View(pedidoMateriais);
        }
    }
}
