using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class Creature : IMovable, ISpeakable, IDrinkable
    {
        protected int totalDistance = 0;
        public int TotalDistance { get => totalDistance; set => totalDistance = value; }

        public virtual void Drink()
        {
            Console.WriteLine("Creature: Ok that's enough");
        }

        void ISpeakable.Speak(string text)
        {
            Console.WriteLine($"This creature says: {text}");
        }

        void IMovable.Run(int meters) => Run(meters);

        protected virtual void Run(int meters)
        {
            TotalDistance += meters;
            Console.WriteLine($"I can run!");
        }
    }
}
