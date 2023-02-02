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
    }
}
