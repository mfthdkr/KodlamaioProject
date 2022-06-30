using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {   
        // Product nesnesine özel metotları buraya yazacaz.

        List<ProductDetailDTO> GetProductDetails();
    }
}
