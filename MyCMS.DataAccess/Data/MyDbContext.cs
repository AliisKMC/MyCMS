using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCMS.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.DataAccess.Data
{
    public class MyDbContext:IdentityDbContext

    {        
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Page> Page { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PageGroup>().HasQueryFilter(g => g.IsDelete == false);
            base.OnModelCreating(builder);
        }
    }
}
