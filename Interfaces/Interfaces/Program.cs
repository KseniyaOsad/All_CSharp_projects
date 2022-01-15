using System;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Animal animal = new Animal();
            Creature creature = new Creature();

            Console.WriteLine("Call Drink method. Method is virtual. Entity to IDrinkable. \n");
            List<IDrinkable> drinkers = new List<IDrinkable> { person , animal, creature};
            foreach (var item in drinkers)
            {
                item.Drink();
            }

            Console.WriteLine("\nJust call Drink method. Method is virtual. \n");
            person.Drink();
            animal.Drink();
            creature.Drink();
            
            Console.WriteLine("\nCall Speak method. The method is implemented explicitly. Entity to ISpeakable \n");
            List<ISpeakable> speakers = new List<ISpeakable> { person, animal, creature };
            foreach (var item in speakers)
            {
                item.Speak("Hello");
            }

            Console.WriteLine("\nJust call Speak method. The method is implemented explicitly. \n");
            // creature.Speak("hello"); - can`t do this. only like this ((ISpeakable)creature).Speak("hello");
            Console.WriteLine("Creature can`t speak like this");
            person.Speak("hello");
            animal.Speak("hello");


            Console.WriteLine("\nCall Move and Run method. Method Move implemented in interface; Run use pattern. Entity to IMovable \n");
            List<IMovable> movers = new List<IMovable> { person, animal, creature };
            foreach (var item in movers)
            {
                item.Move(2);
                item.Run(1);
            }

            Console.WriteLine("\nJust call Move method. Method implemented in interface. \n");
            animal.Move(2);
            Console.WriteLine("Person can`t Move like this");
            // person.Move(2); - can`t do this. only like this ((IMovable)person).Move(2);
            Console.WriteLine("Creature can`t Move like this");
            // creature.Move(2); - can`t do this. only like this ((IMovable)creature).Move(2);


            Console.WriteLine("\nJust call Run method. Method uses pattern. \n");
            Console.WriteLine("All of them can't do like this");
            // person.Run(2); - can`t do this. only like this ((IMovable)person).Run(2);
            // animal.Run(2); - can`t do this. only like this ((IMovable)animal).Run(2);
            // creature.Run(2); - can`t do this. only like this ((IMovable)creature).Run(2);
        }
    }
}
