using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class AppShopContext : DbContext, IUnitOfWork, IDbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public AppShopContext():base("DefaultConnection"){
        }
        public IDbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }
}
