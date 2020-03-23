using System;
using System.Collections.Generic;
using System.Text;
using GraniteHouse_sw2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse_sw2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<SpecialTags> SpecialTags { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
