using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepo
    {
        static TaskDBContext context;

        static ProductRepo()
        {
            context = new TaskDBContext();
        }

        public static List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
    }
}
