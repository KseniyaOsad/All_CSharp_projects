using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates_Events_Exception_tasks
{
    public class SmartHome
    {
        public delegate void ClimatControl();

        public delegate void CallDeliveryService(string adress);

        public event ClimatControl HeatInHouse = () => { };

        public event CallDeliveryService GetIceCream = (string adress) => {  };

        private int temperature = 20;

        public SmartHome(string adr, Phone phone)
        {
            Adress = adr;
            HeatInHouse += CloseAll;
            HeatInHouse += ConditionerOn;
            phone.MakeColderButton += ButtonMakeColderWasClicked;
            phone.CallIceCreamButton += ButtonCallIceCreamWasClicked;
        }

        public string Adress { get; set; }

        public StateEnum Conditioner { get; set; } = StateEnum.Off;

        public StateEnum Door { get; set; } = StateEnum.Close;

        public StateEnum Window { get; set; } = StateEnum.Open;


        public int Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                ClimatHasChanged();
            }
        }

        private void ClimatHasChanged()
        {
            Console.WriteLine($"Temperature has changed, now it {Temperature}");
            if (Temperature >= 30)
            {
                GetIceCream.Invoke(Adress);
                HeatInHouse.Invoke();
            }
            else if(Temperature >= 25)
            {
                HeatInHouse.Invoke();
            }
        }
       
        private void ButtonMakeColderWasClicked()
        {
            Console.WriteLine("Ok... processing request");
            HeatInHouse.Invoke();
        }

        private void ButtonCallIceCreamWasClicked()
        {
            Console.WriteLine("Ok... processing request");
            GetIceCream.Invoke(Adress);
        }

        private void CloseAll()
        {
            Door = StateEnum.Close;
            Window = StateEnum.Close;
            Console.WriteLine("Door and Window are closed!");
        }

        private void ConditionerOn()
        {
            Conditioner = StateEnum.On;
            Console.WriteLine($"Conditioner is working!");
            Temperature -= 5;
        }
    }
}
