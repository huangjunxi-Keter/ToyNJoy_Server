using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ProductPhotoGalleryDAL
    {
        private ToyNjoyContext context;

        public ProductPhotoGalleryDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductPhotoGallery> getByProductId(int id)
        {
            return context.ProductPhotoGalleries.Where(g => g.ProductId == id);
        }

        public bool add(ProductPhotoGallery productPhotoGallery)
        {
            context.ProductPhotoGalleries.Add(productPhotoGallery);
            return context.SaveChanges() > 0;
        }

        public bool del(int productId, string image)
        {
            bool result = false;
            try
            {
                context.ProductPhotoGalleries.Where(p => p.ProductId == productId && p.Image == image).ExecuteDelete();
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
