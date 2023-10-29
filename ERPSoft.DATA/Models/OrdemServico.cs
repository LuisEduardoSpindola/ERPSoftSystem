﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERPSoft.DATA.Models;

public partial class OrdemServico
{
    public int? Cod { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string NomeServico { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string NomeFornecedor { get; set; }

    public int? Total { get; set; }

    [Column(TypeName = "date")]
    public DateTime DataCadastro { get; set; }

    [StringLength(10)]
    public string DataFormatada { get; set; }

    public int? Ordem { get; set; }

    [Key]
    public int Id { get; set; }

    public int IdOrdemPedidoServico { get; set; }

    public int IdOrdemFornecedor { get; set; }

    [ForeignKey("IdOrdemFornecedor")]
    [InverseProperty("OrdemServico")]
    public virtual Fornecedor IdOrdemFornecedorNavigation { get; set; }

    [ForeignKey("IdOrdemPedidoServico")]
    [InverseProperty("OrdemServico")]
    public virtual PedidoServico IdOrdemPedidoServicoNavigation { get; set; }
}