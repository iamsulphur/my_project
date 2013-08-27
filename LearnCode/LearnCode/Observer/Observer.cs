using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// 2013-8-27,JiangJie
    /// 参考《C#本质论》P385
    /// </summary>
    public class Thermostat 
    {
        public delegate void TemperatureChangedHandler(float newTemperature);
        private TemperatureChangedHandler _OnTemperatureChange;

        public TemperatureChangedHandler OnTemperatureChange
        {
            get { return _OnTemperatureChange; }
            set { _OnTemperatureChange = value; }
        }


        private float _CurrentTemperature;

        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set 
            {
                if (value != CurrentTemperature)
                {
                    _CurrentTemperature = value;

                    TemperatureChangedHandler tempHandle = OnTemperatureChange;
                    //需要理解为何使用临时的委托来执行
                    if (tempHandle != null)
                    {
                        tempHandle(value);
                    }
                }
            }
        }
    }


    /// <summary>
    /// 使用事件来实现Themostat
    /// </summary>
    public class Themostat2
    {
        public class TemperatureArgs : System.EventArgs
        {
            public TemperatureArgs(float newTemperature)
            {
                NewTemperature = newTemperature;
            }

            private float _NewTemperature;

            public float NewTemperature
            {
                get { return _NewTemperature; }
                set { _NewTemperature = value; }
            }
        }

        public delegate void TemperatureChangedHandler(object sender,TemperatureArgs newTemperature);
        public event TemperatureChangedHandler OnTemperatureChange = delegate{};

        private float _CurrentTemperature;

        public float CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                if (value != CurrentTemperature)
                {
                    _CurrentTemperature = value;

                    if(OnTemperatureChange!= null)
                    {
                        OnTemperatureChange(this,new TemperatureArgs(value));
                    }
                }
            }
        }
    }
}
