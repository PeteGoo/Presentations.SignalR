using Microsoft.AspNet.SignalR;

namespace SignalR.Sample.Chat.Backup {
    public class ChatPersistentConnection : PersistentConnection {
        protected override System.Threading.Tasks.Task OnReceived(
            IRequest request, 
            string connectionId, 
            string data) {
            return Connection.Broadcast(data);
        }

        
    }
}