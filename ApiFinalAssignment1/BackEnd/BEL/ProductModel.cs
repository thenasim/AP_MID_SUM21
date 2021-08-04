using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ProductModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public string Image { get; set; }


        // Relation
        public virtual CategoryModel Category { get; set; }
    }
}
