using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductService
    {
        public static List<ProductModel> GetAllProducts()
        {
            var data = ProductRepo.GetAllProducts();
            return AutoMapper.Mapper.Map<List<Product>, List<ProductModel>>(data);
        }
    }
}
