using System;
using System.Collections.Generic;
using System.Text;

namespace CovarianceAndContravariance
{
    class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }

        public override void SayName()
        {
            Console.Write("I am Dog and ");
            base.SayName();
        }
    }
}
