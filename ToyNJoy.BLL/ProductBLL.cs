using Microsoft.EntityFrameworkCore.Storage;
using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL;
        private ProductHardwareRequirementDAL productHardwareRequirementDAL;
        private WishListDAL wishListDAL;
        private UserDAL userDAL;
        private ToyNjoyContext context;

        public ProductBLL(ToyNjoyContext context)
        {
            this.context = context;
            productDAL = new ProductDAL(context);
            productHardwareRequirementDAL = new ProductHardwareRequirementDAL(context);
            wishListDAL = new WishListDAL(context);
            userDAL = new UserDAL(context);
        }

        public Product add(Product p)
        {
            p.Image = ".png";
            p.Browse = 0;
            p.Purchases = 0;
            p.Discount /= 10;
            Product result = null;

            using (IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var productEntity = productDAL.add(p);
                    if (productEntity != null && productEntity.Id != null)
                    {
                        ProductHardwareRequirement productHardwareRequirement = new ProductHardwareRequirement(productEntity.Id.Value, "暂未提供");
                        productHardwareRequirementDAL.add(productHardwareRequirement);
                        dbContextTransaction.Commit();
                        result = productEntity;
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public bool upd(Product p)
        {
            bool result = false;
            if (p != null && p.Id != null)
            {
                var product = productDAL.getById(p.Id.Value);

                bool cutPrice = product.Price > p.Price;
                bool discount = p.Discount < 10;

                product.Name = p.Name;
                product.TypeId = p.TypeId;
                product.AgeGrading = p.AgeGrading;
                product.Price = p.Price;
                product.Discount = p.Discount / 10;
                product.Intro = p.Intro;
                product.Developers = p.Developers;
                product.Publisher = p.Publisher;
                product.ReleaseDate = p.ReleaseDate;

                result = productDAL.upd(product);

                if (result && (cutPrice || discount))
                {
                    List<string> usernameList = new List<string>();
                    foreach (WishList wl in wishListDAL.find(product.Id))
                    {
                        usernameList.Add(wl.UserName);
                    }
                    foreach (User u in userDAL.find(usernameList))
                    {
                        string message = string.Format("您愿望单中的商品《{0}》{1}", product.Name, cutPrice ? "降价了" : "正在促销");
                        EmailHelper.SendMail(u.Email, "关于您的愿望单", message);
                    }
                }
            }
            return result;
        }

        public Product getById(int id)
        {
            return productDAL.getById(id);
        }

        public IEnumerable<Product> find(string? name, int? maxPrice, int? minPrice,
            int? typeId, string? orderby, int? page, int? count)
        {
            return productDAL.find(name, maxPrice, minPrice, typeId, orderby, page, count);
        }

        public int findCount(string? name, int? maxPrice, int? minPrice, int? typeId)
        {
            return productDAL.findCount(name, maxPrice, minPrice, typeId);
        }
    }
}
