// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Core.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

////////////////////////////////////////////////////////
Console.WriteLine(new string('-', 10));
ProductManager productManager = new(new EfProductDal());
var result = productManager.GetAll();
if (result.Success == true)
{
    foreach (var product in productManager.GetAll().Data)
    {
        Console.WriteLine(product.ProductName);
    }
}
else Console.WriteLine(result.Message);
////////////////////////////////////////////////////////
Console.WriteLine(new string('-', 10));
CategoryManager categoryManager = new(new EfCategoryDal());
var result2 = categoryManager.GetAll();
if (result2.Success == true)
{
    foreach (var category in result2.Data)
    {
        Console.WriteLine(category.CategoryName);
    }
}
else Console.WriteLine(result2.Message);
////////////////////////////////////////////////////////
Console.WriteLine(new string('-', 10));
var result3 = productManager.GetProductDetails();
if (result3.Success == true)
{
    foreach (var product in result3.Data)
    {
        Console.WriteLine(product.CategoryName);
    }
}
else Console.WriteLine(result3.Message);