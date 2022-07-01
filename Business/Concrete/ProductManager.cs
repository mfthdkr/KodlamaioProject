using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IDataResult<List<Product>> GetAll()
        {
            // iş kodları : yetki kontrolü, if statements vs.
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult();
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductAdded);
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

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public IResult Add(Product product)
        {   
            // business codes 
            // magic strings
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
