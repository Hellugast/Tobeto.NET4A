﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // T => Type
    public interface IRepository<T>
    {
        T? Get(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>>? predicate = null);
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
    }
}
