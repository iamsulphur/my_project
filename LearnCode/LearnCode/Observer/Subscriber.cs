using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Cooler
    {
        public Cooler(float temperature)
        {
            Temperature = temperature;
        }

        private float _Temperature;

        public float Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }

        public void OnTemperatureChanged(object sender, Themostat2.TemperatureArgs args)
        {
            if (args.NewTemperature > Temperature)
            {
                System.Console.Write("Cooler:ON!");
            }
            else
            {
                System.Console.Write("Cooler:OFF!");
            }
        }

    }


    public class Heater
    {
        public Heater(float temperature)
        {
            Temperature = temperature;
        }

        private float _Temperature;

        public float Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }

        //public void OnTemperatureChanged(float newTemperature)
        //{
        //    if (newTemperature < Temperature)
        //    {
        //        System.Console.Write("Heater:ON!");
        //    }
        //    else
        //    {
        //        System.Console.Write("Heater:OFF!");
        //    }
        //}

        /// <summary>
        /// 使用事件改造
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTemperatureChanged(object sender,Themostat2.TemperatureArgs args)
        {
            if (args.NewTemperature < Temperature)
            {
                System.Console.Write("Heater:ON!");
            }
            else
            {
                System.Console.Write("Heater:OFF!");
            }
        }
    }
}
