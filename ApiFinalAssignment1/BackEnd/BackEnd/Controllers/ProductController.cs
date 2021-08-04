using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/Product/GetAll")]
        public List<ProductModel> GetAllStudents()
        {
            return ProductService.GetAllProducts();
        }
    }
}
