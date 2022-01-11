using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CovarianceAndContravariance
{
    public interface ICustomCollection<in T, out K> 
    {
        public void Add(T item);
        public K GetList();
    }
}
