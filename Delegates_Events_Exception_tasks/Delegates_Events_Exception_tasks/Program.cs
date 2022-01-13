using System;

namespace Delegates_Events_Exception_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create phones.
            Phone phone1 = new Phone();
            Phone phone2 = new Phone();

            // Create homes.
            SmartHome home1 = new SmartHome("Obolonskiy prospect 40d", phone1);
            SmartHome home2 = new SmartHome("Naberejnaya 10", phone2);

            // Test changing temperature. Without calling ice cream.
            home1.Temperature = 25;
            Console.WriteLine();
            home2.Temperature = 30;
            Console.WriteLine();

            // Test pressing buttons on phones. Without calling ice cream.
            phone1.CallIceCream();
            Console.WriteLine();
            phone1.MakeColder();
            Console.WriteLine();

            phone2.CallIceCream();
            Console.WriteLine();
            phone2.MakeColder();
            Console.WriteLine();

            // Create bus. Add subscribers
            IceCreamBus bus = new IceCreamBus();
            bus.AddSubscribe(home1);
            bus.AddSubscribe(home2);

            // Test calling ice cream
            phone1.CallIceCream();
            Console.WriteLine();
            phone2.CallIceCream();
            Console.WriteLine();

            // Test changing temperature
            home1.Temperature = 30;

            bus.RemoveSubscribe(home1);

            // Test calling ice cream
            phone1.CallIceCream();

        }
    }
}
