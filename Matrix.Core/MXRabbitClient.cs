using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Core
{
    public class MXRabbitClient
    {
        static string _connectionString;

        static Lazy<IBus> _bus = new Lazy<IBus>(() => RabbitHutch.CreateBus(_connectionString));
        
        static MXRabbitClient() 
        {
            _connectionString = ConfigurationManager.AppSettings["rabbitMQConnectionString"]; 
        }

        private MXRabbitClient() { }

        public static IBus Bus
        { 
            get 
            {                
                return _bus.Value;
            } 
        }
    }
}
