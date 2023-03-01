using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.DAL;

namespace ToyNJoy.BLL
{
    public class ProductPhotoGalleryBLL
    {
        private ProductPhotoGalleryDAL productPhotoGalleryDAL;
        private ToyNjoyContext context;

        public ProductPhotoGalleryBLL(ToyNjoyContext context)
        {
            this.context = context;
            productPhotoGalleryDAL = new ProductPhotoGalleryDAL(context);
        }

        public IEnumerable<ProductPhotoGallery> getByProductId(int id) 
        {
            return productPhotoGalleryDAL.getByProductId(id);
        }

        public bool add(int productId, string image)
        {
            ProductPhotoGallery productPhotoGallery = new ProductPhotoGallery();
            productPhotoGallery.ProductId = productId;
            productPhotoGallery.Image = image;
            productPhotoGallery.JoinDate = DateTime.Now;

            return productPhotoGalleryDAL.add(productPhotoGallery);
        }

        public bool del(int productId, string image)
        { 
            return productPhotoGalleryDAL.del(productId, image);
        }
    }
}
