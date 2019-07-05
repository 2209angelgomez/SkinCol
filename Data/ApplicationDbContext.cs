using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkinCol.Models;

namespace SkinCol.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SkinCol.Models.Proveedor> Proveedor { get; set; }
        public DbSet<SkinCol.Models.Material> Material { get; set; }
        public DbSet<SkinCol.Models.FacturaInsumos> FacturaInsumos { get; set; }
    }
}
