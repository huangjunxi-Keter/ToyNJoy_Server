using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class ProductBLL
    {
        private ProductDAL dal = new ProductDAL();

        public bool add(Product p) { 
            return dal.add(p);
        }

        public bool del(String id) {
            return dal.del(id);
        }

        public bool upd(Product p) {
            return dal.upd(p);
        }

        public IEnumerable<Product> find() {
            return dal.find();
        }
    }
}
