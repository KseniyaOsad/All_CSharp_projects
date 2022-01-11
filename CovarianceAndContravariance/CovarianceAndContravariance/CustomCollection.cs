using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CovarianceAndContravariance
{
    class CustomCollection<T> : ICustomCollection<T, List<T>>
    {
        List<T> animals = new List<T>();
        public void Add(T item)
        {
            animals.Add(item);
        }

        public List<T> GetList()
        {
            return animals;
        }
    }
}
