using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ERPSoft.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
public class Usuario : IdentityUser
{
    public int Ide { get; set; }
    public string Nome { get; set; }
    public string Departamento { get; set; }
    public int Matricula { get; set; }
}

