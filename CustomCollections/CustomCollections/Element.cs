using System;
using System.Collections.Generic;
using System.Text;

namespace CustomCollections
{
    public class Element<T>
    {
        public T Value { get; set; }

        public Element<T> Next { get; set; } = null;

        public Element(T val)
        {
            Value = val;
        }
    }
}
