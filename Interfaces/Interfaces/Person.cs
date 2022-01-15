using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class Person : Creature, ISpeakable
    {
        public override void Drink()
        {
            Console.WriteLine("Person: Start drinking Cola...");
        }
        
        public void Speak(string text)
        {
            Console.WriteLine($"My own method Speak. I am Speakable. This person says: {text}");
        }

        protected override void Run(int meters)
        {
            Console.Write("I`m person. ");
            base.Run(meters);
        }
    }
}
