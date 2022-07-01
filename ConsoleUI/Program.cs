// SOLID
// Open Closed Principle
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore.Query.Internal;

// CategoryTest();

// ProductTest();

GetProductDetails();

void GetProductDetails()
{
    ProductManager productManager = new ProductManager(new EfProductDal());
    var result = productManager.GetProductDetails();

    if (result.Success)
    {
        foreach (var productDetailDto in result.Data)
        {
            Console.WriteLine(productDetailDto.ProductName + " " + productDetailDto.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}

void ProductTest()
{
    // IoC Container ile yapıcaz daha sonra
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var product in productManager.GetByUnitPrice(40, 100).Data)
    {
        Console.WriteLine(product.ProductName);
    }
}
void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}









