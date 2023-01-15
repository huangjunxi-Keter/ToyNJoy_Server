using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ProductPhotoGalleryDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public IEnumerable<ProductPhotoGallery> getByProductId(int id) 
        {
            return db.ProductPhotoGalleries.Where(g => g.ProductId == id);
        }
    }
}
