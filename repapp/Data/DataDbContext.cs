using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using repapp.Data.Entities;


namespace repapp.Data
{
    public class DataDbContext: IdentityDbContext<StoreUser>
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {
        }

     public DbSet<Product> Products { get; set; }

    }
}
