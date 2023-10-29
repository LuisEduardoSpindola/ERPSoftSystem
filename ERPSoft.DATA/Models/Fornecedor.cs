﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.DATA.Models;

public partial class Fornecedor
{
    [Required]
    [StringLength(150)]
    public string Nome { get; set; }

    [Required]
    [StringLength(250)]
    public string Endereco { get; set; }

    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    public int Cnpj { get; set; }

    public int InscEstadual { get; set; }

    public int InscMunicipal { get; set; }

    [Column("CEP")]
    public int? Cep { get; set; }

    public bool OrdemVinc { get; set; }

    [Key]
    public int Id { get; set; }

    [InverseProperty("IdEntradaFornecedorNavigation")]
    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    [InverseProperty("IdOrdemFornecedorNavigation")]
    public virtual ICollection<OrdemCompra> OrdemCompra { get; set; } = new List<OrdemCompra>();

    [InverseProperty("IdOrdemFornecedorNavigation")]
    public virtual ICollection<OrdemServico> OrdemServico { get; set; } = new List<OrdemServico>();

    [InverseProperty("IdPedidoSfornecedorNavigation")]
    public virtual ICollection<PedidoServico> PedidoServico { get; set; } = new List<PedidoServico>();

    [InverseProperty("IdSaidaFornecedorNavigation")]
    public virtual ICollection<Saida> Saida { get; set; } = new List<Saida>();

    [InverseProperty("IdFornecedorNavigation")]
    public virtual ICollection<Servicos> Servicos { get; set; } = new List<Servicos>();
}