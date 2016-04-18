using System.Data.Entity;
using IUD.DataAccess.Entities;

namespace IUD.DataAccess.Context
{
    public class DbEntities : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }


    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        void SaveChanges();
    }
}