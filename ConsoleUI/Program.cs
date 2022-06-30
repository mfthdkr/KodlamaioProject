// SOLID
// Open Closed Principle
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore.Query.Internal;


// ProductTest();

// CategoryTest();

ProductManager productManager = new ProductManager(new EfProductDal());
foreach (var productDetailDto in productManager.GetProductDetails())
{
    Console.WriteLine(productDetailDto.ProductName + " " + productDetailDto.CategoryName);   
}


void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}

void ProductTest()
{
    // IoC Container ile yapıcaz daha sonra
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var product in productManager.GetByUnitPrice(40, 100))
    {
        Console.WriteLine(product.ProductName);
    }
}





