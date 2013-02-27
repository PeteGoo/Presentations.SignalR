using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ClientApp {
    class Program {
        static void Main(string[] args) {
            Connection connection = new Connection("http://petegoosignalrtalk.azurewebsites.net/chat");
            connection.Received += Console.WriteLine;
            connection.Start().Wait();

            while (true) {
                string message = Console.ReadLine();
                connection.Send("Console: " + message);
            }
        }
    }
}
