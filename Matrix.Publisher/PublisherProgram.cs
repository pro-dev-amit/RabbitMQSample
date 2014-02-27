using EasyNetQ;
using Matrix.Core;
using Matrix.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix.Processor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = new MXRabbitBus("host=localhost").Bus)
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {                    
                    bus.Publish(new MXEmployee
                    {
                        Id = 105,
                        Name = "Amit Kumar",
                        Skills = new List<string> { ".Net", "Rails", "ASP.Net MVC" },
                    });                    
                }
            }
        }//End of Main
    }
}
