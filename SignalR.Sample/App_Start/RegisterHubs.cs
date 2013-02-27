using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using SignalR.Sample.Chat;
using SignalR.Sample.SharedTodos;

[assembly: WebActivator.PreApplicationStartMethod(typeof(SignalR.StockTicker.RegisterHubs), "Start")]

namespace SignalR.StockTicker
{
    public static class RegisterHubs
    {
        public static void Start() {
            RouteTable.Routes.MapConnection<ChatPersistentConnection>("chat", "chat");



            RouteTable.Routes.MapConnection<TodoNotificationConnection>("todonotification", "todonotification");
            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapHubs();
        }
    }
}
