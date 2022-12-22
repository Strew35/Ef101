// See https://aka.ms/new-console-template for more information
using Business.Abstract;
using Business.Concrete;
using Core.Concrete.EntityFramework;
using Entities.Concrete;

////////////////////////////////////////////////////////
Console.WriteLine(new string('-', 10));
ProductManager productManager = new(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
Core.Utilities.Results.Abstract.IDataResult<List<Product>> result = productManager.GetAll();
if (result.Success == true)
{
    foreach (Product product in productManager.GetAll().Data)
    {
        Console.WriteLine(product.ProductName);
    }
}
else
{
    Console.WriteLine(result.Message);
}
////////////////////////////////////////////////////////
Console.WriteLine(new string('-', 10));
CategoryManager categoryManager = new(new EfCategoryDal());
Core.Utilities.Results.Abstract.IDataResult<List<Category>> result2 = categoryManager.GetAll();
if (result2.Success == true)
{
    foreach (Category category in result2.Data)
    {
        Console.WriteLine(category.CategoryName);
    }
}
else
{
    Console.WriteLine(result2.Message);
}
////////////////////////////////////////////////////////
Console.WriteLine(new string('-', 10));
Core.Utilities.Results.Abstract.IDataResult<List<Entities.DTOs.ProductDetailDto>> result3 = productManager.GetProductDetails();
if (result3.Success == true)
{
    foreach (Entities.DTOs.ProductDetailDto product in result3.Data)
    {
        Console.WriteLine(product.CategoryName);
    }
}
else
{
    Console.WriteLine(result3.Message);
}