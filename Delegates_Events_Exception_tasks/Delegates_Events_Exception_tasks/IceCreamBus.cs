using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates_Events_Exception_tasks
{
    public class IceCreamBus
    {
        List<SmartHome> homes { get; }

        public int SubscribersCount { get=>homes.Count; }

        public IceCreamBus()
        {
            homes = new List<SmartHome>();
        }

        public void AddSubscribe(SmartHome home)
        {
            homes.Add(home);
            home.GetIceCream += BringIceCream;
            Console.WriteLine($"New subscriber, adress: {home.Adress}! Subscribers Count is {SubscribersCount}\n");
        }

        public void RemoveSubscribe(SmartHome home)
        {
            homes.Remove(home);
            home.GetIceCream -= BringIceCream;
            Console.WriteLine($"\nRemove subscriber, adress: {home.Adress}! Subscribers Count is {SubscribersCount}\n");
        }

        private void BringIceCream(string adress)
        {
            Console.WriteLine($"I will bring ice cream to the adress {adress}");
        }
    }
}
