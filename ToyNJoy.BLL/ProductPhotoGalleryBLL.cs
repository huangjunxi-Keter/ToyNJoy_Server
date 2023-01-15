using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.DAL;

namespace ToyNJoy.BLL
{
    public class ProductPhotoGalleryBLL
    {
        private ProductPhotoGalleryDAL dal = new ProductPhotoGalleryDAL();

        public IEnumerable<ProductPhotoGallery> getByProductId(int id) 
        {
            return dal.getByProductId(id);
        }
    }
}
