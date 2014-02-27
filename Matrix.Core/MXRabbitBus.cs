using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Core
{
    public class MXRabbitBus : IDisposable
    {
        IBus _bus;
        string _connectionString;

        public MXRabbitBus(string connectionString) 
        {
            _connectionString = connectionString;
 
        }

        public IBus Bus
        { 
            get 
            {
                _bus = RabbitHutch.CreateBus(_connectionString);
                return _bus;
            } 
        }

        public void Dispose()
        {
            if(_bus != null) _bus.Dispose();
        }
    }
}
