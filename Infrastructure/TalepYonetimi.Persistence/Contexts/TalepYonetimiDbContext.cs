﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Persistence.Extensions;

namespace TalepYonetimi.Persistence.Contexts
{
    public class TalepYonetimiDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        // identity 2. adım
        // dbcontext e identity yi kullanacağımızı bildiriyoruz, identityDbContext ten miras alıp user ve role entitylerini veriyoruz.
        public TalepYonetimiDbContext(DbContextOptions<TalepYonetimiDbContext> options) : base(options)
        {
            
        }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.CreateData();
        }
    }
}
