using ERPSoft.DATA.Interfaces;
using ERPSoft.DATA.Models;
using ERPSoft.DATA.Repositories;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Identity;
using ERPSoft.Web.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ERPSoftDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<ERPSoftIdentityContext>(options => options.UseSqlServer(connection));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<ERPSoftIdentityContext>();

builder.Services.AddScoped<IProduto, RepositoryProduto>();
builder.Services.AddScoped<IFornecedor, RepositoryFornecedor>();
builder.Services.AddScoped<IServico, RepositoryServico>();
builder.Services.AddScoped<IEntrada, RepositoryEntrada>();
builder.Services.AddScoped<ISaida, RepositorySaida>();
builder.Services.AddScoped<IPedidoMaterial, RepositoryPedidoMaterial>();
builder.Services.AddScoped<IPedidoServico, RepositoryPedidoServico>();
builder.Services.AddScoped<IOrdemCompra, RepositoryOrdemCompra>();
builder.Services.AddScoped<IOrdemServico, RepositoryOrdemServico>();


CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
customCulture.NumberFormat.CurrencyDecimalSeparator = ".";
customCulture.NumberFormat.CurrencyGroupSeparator = ",";
CultureInfo.CurrentCulture = customCulture;
CultureInfo.CurrentUICulture = customCulture;

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



