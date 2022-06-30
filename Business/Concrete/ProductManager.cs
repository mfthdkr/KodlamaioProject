using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{

    // Manager : iş katmanının somut sınıfı
    public class ProductManager : IProductService
    {
        // Kural : Bir iş sınıfı başka sınıfları newlemez.
        // injection yaptık ,Soyut nesne ile bağlantı kurduk. Ne InMemoryProdcutDal ne de EntityFramework kullandık. Burası çokomelli.
        //ProductManageer() newlendiğinde ister InMemoryProductDal ister de EntityFramework in  somut  classını kullanırız.Switch yapma imkanımız oldu.
        // Hangi yapıyı kullacağımıza bir üst katmanda karar vericez.
        // Örn: ConsoleUI katmanının program.cs inde "ProductManager productManager = new ProductManager(new InMemoryProductDal());" bu komut ile karar verdik.
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            // iş kodları : yetki kontrolü, if statements vs.
            return _productDal.GetAll();
        }

        public List<Product> GetByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
