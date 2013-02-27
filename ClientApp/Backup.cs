using System;
using Microsoft.AspNet.SignalR.Client;

namespace ClientApp {
    public class Backup {
        public void Foo() {
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