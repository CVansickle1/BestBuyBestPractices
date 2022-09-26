using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);



var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();

}


  
var productRepository = new DapperProductRepository(conn);

var products = productRepository.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine($"${product.Price}");
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale ? "On Sale" : "Not On Sale");
    Console.WriteLine($"Quantity On Hand: {product.StockLevel}");
    Console.WriteLine();
    Console.WriteLine();

}

string? Name;
double Price;
int CategoryID;

var foundExeption = false;

do
{
    try
    {
        Console.WriteLine("Please Enter the Name, Price and CategoryID that you would like to Insert");
        Name = Console.ReadLine();
        Price = double.Parse(Console.ReadLine());
        CategoryID = int.Parse(Console.ReadLine());
        productRepository.CreateProduct(Name, Price, CategoryID);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        foundExeption = true;

    }
}
while (foundExeption);

