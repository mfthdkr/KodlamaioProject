using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    // iş kodlarını genellikle Service diye yazarız.
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<ProductDetailDTO> GetProductDetails();
    }
}
