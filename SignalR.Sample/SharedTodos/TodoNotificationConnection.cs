using Microsoft.AspNet.SignalR;

namespace SignalR.Sample.SharedTodos {
    public class TodoNotificationConnection : PersistentConnection {
        protected override System.Threading.Tasks.Task OnReceived(IRequest request, string connectionId, string data) {
            return Connection.Broadcast(data);
        }
    }
}