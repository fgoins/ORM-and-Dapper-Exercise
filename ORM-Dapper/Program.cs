using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;
//on the first line hit CRTL dot and it will your using directive..


var config = new ConfigurationBuilder()// 1.this is your config key word "config" above.\
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");// 2.then with the config we grabbed the connection string (connString).

IDbConnection conn = new MySqlConnection(connString); //3. then created our connection to the database.

#region Department Section 
var departmentRepo = new DapperDepartmentRepository(conn);//add using directive CRTL dot

departmentRepo.InsertDepartment("faith's New Department"); //will add a new depart space line not needed just a tester//.

var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}
#endregion //to create a region #region Department Section and at the bottom #endregion...


#region Product Section
var productRepository = new DapperProductRepository(conn);
var products = productRepository.GetAllProducts();

foreach(var product in products) 
{
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.Stocklevel);
    Console.WriteLine();
    Console.WriteLine();
}
#endregion


