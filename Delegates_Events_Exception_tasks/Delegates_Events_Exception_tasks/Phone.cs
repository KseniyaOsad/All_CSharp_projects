using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates_Events_Exception_tasks
{
    public class Phone
    {
        public delegate void ButtonClick();

        public event ButtonClick MakeColderButton = () => { };

        public event ButtonClick CallIceCreamButton = () => { };

        public void MakeColder()
        {
            Console.WriteLine("Make Colder Button was clicked!");
            MakeColderButton.Invoke();
        }

        public void CallIceCream()
        {
            Console.WriteLine("Call Ice Cream Button was clicked!");
            CallIceCreamButton.Invoke();
        }
    }
}
