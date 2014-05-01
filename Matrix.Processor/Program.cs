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
                bus.SubscribeAsync<MXEntity>("test", HandleMessage);

                bus.Respond<MXEntity, MXEmployeeQueueResponse>(c => RespondInRPCWay(c));

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                
                Console.ResetColor();

                Console.ReadLine();
            }
        }
        
        static Task HandleMessage(MXEntity messageInput)
        {
            return Task.Run(() =>
                {
                    var message = messageInput as MXEmployee;

                    Console.WriteLine("-----------------Processing now...-----------------");

                    Thread.Sleep(2000);

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Id: {0}\nName: {1}\nSkills: {2}", message.Id, message.Name, string.Join(", ", message.Skills));

                    Console.ResetColor();

                    Console.WriteLine("\n-----------------Processing Complete..-----------------");
                });
        }

        static MXEmployeeQueueResponse RespondInRPCWay(MXEntity messageInput)
        {
            var message = messageInput as MXEmployee;

            MXEmployeeQueueResponse response;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Message received is as:");

            Console.WriteLine("Id: {0}\nName: {1}\nSkills: {2}", message.Id, message.Name, string.Join(", ", message.Skills));

            Console.ResetColor();

            Console.WriteLine("-----------------Processing RPC ...-----------------");
            //doing something with the message now
            response = new MXEmployeeQueueResponse { Employee = message };
            response.Employee.Skills.Add("Solr Search");

            Console.WriteLine("\n-----------------Processing RPC Complete..-----------------");

            return response;
        }
    }//End of Class "Program"
}
