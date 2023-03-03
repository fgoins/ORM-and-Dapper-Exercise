using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository //conform to Product repo and dont forget to implement your interface (CRTL dot).
    {
        private readonly IDbConnection _conn;// Short cut - CRTL dot to generate conductor
         public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()//in order to call the database we have to make a connection.
        {
            return _conn.Query<Product>("SELECT * FROM Products;");
            //now with _conn object you can return all of the products from SQL 
        }
    }
}
