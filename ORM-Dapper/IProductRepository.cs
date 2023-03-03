﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); //this is the get products method.
    }
}
