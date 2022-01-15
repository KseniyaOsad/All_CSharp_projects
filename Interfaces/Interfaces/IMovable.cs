using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    interface IMovable
    {
        int TotalDistance { get; set; }

        void Move(int meters) {
            TotalDistance += meters;
            Console.WriteLine($"Ok.. I walked - {meters}meters,  TotalDistance = {TotalDistance}.");
        }

        void Run(int meters);
    }
}
