using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ProductDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public bool add(Product p)
        {
            db.Add(p);
            return db.SaveChanges() > 0;
        }

        public bool del(string id)
        {
            db.Remove(id);
            return db.SaveChanges() > 0;
        }

        public bool upd(Product p)
        {
            db.Update(p);
            return db.SaveChanges() > 0;
        }

        public IEnumerable<Product> find()
        {
            return db.Products.ToList();
        }
    }
}
