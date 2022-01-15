using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class Animal : Creature
    {
        public override void Drink()
        {
            Console.Write("Animal is drinking... base: ");
            base.Drink();
        }

        public void Speak(string text)
        {
            Console.WriteLine($"My own method Speak. I am not speakable. This animal says: {text}");
            //base.Speak(); - can`t do this
        }

        public void Move(int distance)
        {
            Console.Write($"My own method move. Animal distance before - {TotalDistance}, ");
            TotalDistance += distance*2;
            Console.WriteLine($"Now - {TotalDistance}.");
        }

        protected override void Run(int meters)
        {
            Console.Write("I`m animal. ");
            base.Run(meters);
        }
    }
}
