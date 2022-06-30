using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {   
        // metodların dışında tanımlanan değişkenler alt çizgi " _ " ile başlar
        List<Product> _products;

        public InMemoryProductDal()
        {   
            // Bellekte örnek veri oluşturduk :  Veri tabanı yerine 
            _products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Bardak",
                    UnitPrice = 15,
                    UnitsInStock = 15
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "Kamera",
                    UnitPrice = 500,
                    UnitsInStock = 3
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ProductName = "Telefon",
                    UnitPrice = 1500,
                    UnitsInStock = 2
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    ProductName = "Klavye",
                    UnitPrice = 150,
                    UnitsInStock = 65
                },
                new Product
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ProductName = "Fare",
                    UnitPrice = 85,
                    UnitsInStock = 1
                },
            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {   
            // Gönderdiğim ürün Id'sine sahip olan listedediki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

        public void Delete(Product product)
        {   
            // LINQ - Language Integrated Query
            // Lambda : =>
            Product productToDelete = null;

            #region Linq kullanmadan

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            #endregion

            // SingleOrDefault() ilk kaydı döner. Id bazlı yapılarda kullanabiliriz.
            // _products listesinin her bir elemanına p ismi verildi. Her p için parametre olarak gelen product'ın ProductId ' si eşit mi diye kontrol edildi.
            productToDelete = _products.SingleOrDefault(p=>p.ProductId== product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {   
            // Where() içindeki şarta uyanları biraraya getirir.İstediğimiz kadar koşul ekleyebiliriz.
           return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
