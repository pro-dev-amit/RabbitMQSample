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
                bus.Subscribe<MXEmployee>("test", HandleMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleMessage(MXEntity messageInput)
        {
            //throw new Exception();
            Console.WriteLine("-----------------Processing now...-----------------");

            var message = messageInput as MXEmployee;
            
            Thread.Sleep(5000);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0} {1}", message.Id, message.Name);

            foreach (var item in message.Skills)
            {
                Console.Write(item);
            }
            
            Console.ResetColor();

            Console.WriteLine("\n-----------------Processing Complete..-----------------");
        }
    }
}
