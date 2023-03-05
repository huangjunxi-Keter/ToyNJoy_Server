using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace ToyNJoy.DAL
{
    public class ProductTypeDAL
    {
        private ToyNjoyContext context;

        public ProductTypeDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductType> find(string name, int? state, int? page, int? count) 
        {
            IQueryable<ProductType> result = context.ProductTypes;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.TypeName.Contains(name));
            if (state != null)
                result = result.Where(x => x.State == state);
            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);

            return result;
        }

        public int findCount(string name, int? state)
        {
            IEnumerable<ProductType> result = context.ProductTypes;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.TypeName.Contains(name));
            if (state != null)
                result = result.Where(x => x.State == state);
            return result.Count();
        }

        public bool add(ProductType productType)
        {
            context.ProductTypes.Add(productType);
            return context.SaveChanges() > 0;
        }

        public bool upd(ProductType productType)
        {
            context.ProductTypes.Update(productType);
            return context.SaveChanges() > 0;
        }

        public bool del(int id)
        {
            bool result = false;
            try
            {
                context.ProductTypes.Where(x => x.Id == id).ExecuteDelete();
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return result;
        }
    }
}
