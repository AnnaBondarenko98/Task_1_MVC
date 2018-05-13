﻿using System;
using System.Collections.Generic;

namespace BlogAsp.BLL.DALInterfaces
{
    /// <summary>
    /// Common Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
