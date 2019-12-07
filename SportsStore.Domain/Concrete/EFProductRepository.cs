using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product UpdatedProduct = context.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();                
                UpdatedProduct.Name = product.Name;
                UpdatedProduct.Description = product.Description;
                UpdatedProduct.Price = product.Price;
                UpdatedProduct.Category = product.Category;
                UpdatedProduct.ImageData = product.ImageData;
                UpdatedProduct.ImageMimeType = product.ImageMimeType;
            }
            context.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
