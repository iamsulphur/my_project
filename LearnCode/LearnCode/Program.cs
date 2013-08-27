using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Observer;

namespace LearnCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Observer.Cooler cool = new Observer.Cooler(15);
            Observer.Heater heat = new Observer.Heater(20);

            Observer.Themostat2 thermostat = new Observer.Themostat2();
            thermostat.OnTemperatureChange += cool.OnTemperatureChanged;
            thermostat.OnTemperatureChange += heat.OnTemperatureChanged;
            Console.WriteLine("Please enter the new temperature!");

            string StrTemp;
            float temperature;
            StrTemp = Console.ReadLine();
            if (float.TryParse(StrTemp, out  temperature))
            {
                thermostat.CurrentTemperature = temperature;
            }
            Console.ReadKey();
        }
    }
}
