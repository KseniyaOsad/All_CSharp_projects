using System;
using System.Collections.Generic;
using System.Linq;

namespace CovarianceAndContravariance
{
    class Program
    {

        static void Main(string[] args)
        {
            ICustomCollection<Animal, List<Animal>> list = new CustomCollection<Animal>();
            ICustomCollection<Dog, List<Animal>> listDog = list;
            listDog.Add(new Dog("Siri"));
            listDog.GetList().ForEach(animal => animal.SayName());

            ICustomCollection<Animal, List<Animal>> animalsList = new CustomCollection<Animal>();
            animalsList.Add(new Animal("Optimus"));
            animalsList.Add(new Animal("Alis"));
            animalsList.GetList().ForEach(animal => animal.SayName());

            ICustomCollection<Dog, List<Animal>> dogsList = new CustomCollection<Animal>();
            dogsList.Add(new Dog("Gru"));
            dogsList.Add(new Dog("Gigi"));
            dogsList.GetList().ForEach(animal => animal.SayName());

            ICustomCollection<Dog, List<Dog>> dogsList2 = new CustomCollection<Dog>();
            dogsList2.Add(new Dog("Nevada"));
            dogsList2.Add(new Dog("Esqel"));
            dogsList2.GetList().ForEach(animal => animal.SayName());

        }
    }
}
