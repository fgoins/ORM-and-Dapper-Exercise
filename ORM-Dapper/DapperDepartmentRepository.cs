using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository //CRTL dot on the class to implent the parent class
    {
        private readonly IDbConnection _conn; //best practice for a private field it to prefix it with an UnderScore ex. _nameYouWant
                                              //control dot on the IDbconnection to add the using directive.
        public DapperDepartmentRepository(IDbConnection conn) //CRTL dot the _conn or what you choose to name -then select generate constructor.
        {
            _conn = conn;
        }
        //lines 14-17 is you parameterized constructor ,that forces you pass the instance of your class in connection to a database.

        public IEnumerable<Department> GetAllDepartments()
        {
            //inside the method you need to Query the data base.
            //we need a connection first - then with the connection object we can query our info.
            //we created our config in program class already 
            return _conn.Query<Department>("SELECT * FROM departments");
            //you can return the _conn object and use it to connect the Query database and pass in the type <Departments> and add using directive
            //in the parameters pass in the code from SQL in this case we wanted all from departments
        }
        public void InsertDepartment(string name) //were not going to return anything were just going to do somethinng so the return type will be void.
        {
            //we wont be queryiing we will be excuting passing SQl into the parameters.
            _conn.Execute("INSERT INTO deparments (Name) VALUES (@name)", new {name = name});
            //we are assigning the variable name to the string name.
        }


    }
}
