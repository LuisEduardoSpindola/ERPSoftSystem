using ERPSoft.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ERPSoft.DATA.Models;

namespace ERPSoft.Web.Areas.Identity.Data;

public class ERPSoftIdentityContext : IdentityDbContext<Usuario>
{
    public ERPSoftIdentityContext(DbContextOptions<ERPSoftIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ERPSoft.DATA.Models.PedidoServico> PedidoServico { get; set; } = default!;

    public DbSet<ERPSoft.DATA.Models.PedidoMaterial> PedidoMaterial { get; set; } = default!;

    public DbSet<ERPSoft.DATA.Models.OrdemServico> OrdemServico { get; set; } = default!;

    public DbSet<ERPSoft.DATA.Models.OrdemCompra> OrdemCompra { get; set; } = default!;
}
