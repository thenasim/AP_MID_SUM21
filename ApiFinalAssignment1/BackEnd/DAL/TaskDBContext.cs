using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaskDBContext: DbContext
    {
        public TaskDBContext(): base("name=DbConnectionString")
        {
            var dbCreate = new MigrateDatabaseToLatestVersion<TaskDBContext, Configuration>();
            Database.SetInitializer(dbCreate);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
