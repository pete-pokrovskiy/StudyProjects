using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DutchTreatAspNetCore.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DutchTreatAspNetCore.Data
{
    public class DutchContext : IdentityDbContext<StoreUser>
    {
        public DutchContext(DbContextOptions<DutchContext> options) : base(options)
        {
                
        }

        //в версии 2 названия таблиц соответствуют DbSet-ам, то есть получается, что во множественном числе
        //варианты, чтобы вернуть единственное число - https://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
