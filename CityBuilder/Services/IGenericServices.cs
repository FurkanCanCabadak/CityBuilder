﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Services
{
    interface IGenericServices<T>
    {
        bool Add(T entity);
        bool Delete(int id);
        T Detail(int id);
        bool Edit(T entity);
        List<T> List(int Id);
    }
}
