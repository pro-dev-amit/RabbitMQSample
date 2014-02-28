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
            using (var bus = MXRabbitClient.Bus)
            {
                bus.Subscribe<MXEntity>("test", HandleMessage);

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                
                Console.ResetColor();

                Console.ReadLine();
            }
        }

        static void HandleMessage(MXEntity messageInput)
        {            
            Console.WriteLine("-----------------Processing now...-----------------");

            Thread.Sleep(5000);

            var message = messageInput as MXEmployee;

            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine("Id: {0}\nName: {1}\nSkills: {2}", message.Id, message.Name, string.Join(", ", message.Skills));
                        
            Console.ResetColor();

            Console.WriteLine("\n-----------------Processing Complete..-----------------");
        }
    }
}
