using EasyNetQ;
using Matrix.Core;
using Matrix.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = MXRabbitClient.Bus)
            {
                var input = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press Enter to publish a message. 'Q' to quit.");

                Console.ResetColor();

                while ((input = Console.ReadLine()) != "Q")
                {                    
                    bus.Publish<MXEntity>(new MXEmployee
                    {
                        Id = 105,
                        Name = "Amit Kumar",
                        Skills = new List<string> { ".Net", "ASP.Net MVC", "oh Rails" },
                    });                    
                }
            }
        }//End of Main
    }
}
