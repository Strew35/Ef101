// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Core.Concrete.EntityFramework;
using Entities.Concrete;

Console.WriteLine(new string('-', 10));
ProductManager productManager = new(new EfProductDal());
foreach (var product in productManager.GetAll())
{
    Console.WriteLine(product.ProductName);
}
Console.WriteLine(new string('-', 10));
CategoryManager categoryManager = new(new EfCategoryDal());
foreach (var category in categoryManager.GetAll())
{
    Console.WriteLine(category.CategoryName);
}
Console.WriteLine(new string('-', 10));
foreach (var product in productManager.GetProductDetails())
{
    Console.WriteLine(product.CategoryName);
}