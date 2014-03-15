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
                        Skills = new List<string> { ".Net", "ASP.Net MVC", "Rails" },
                    });

                    var response = bus.Request<MXEntity, MXEmployeeQueueResponse>(new MXEmployee
                    {
                        Id = 108,
                        Name = "Max Payne",
                        Skills = new List<string> { "Java", "Rails" },
                    });

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("---------Response Recieved-----------");

                    Console.WriteLine("Id: {0}\nName: {1}\nSkills: {2}", response.Employee.Id, response.Employee.Name, string.Join(", ", response.Employee.Skills));
                    
                    Console.ResetColor();
                }
            }
        }//End of Main
    }
}
