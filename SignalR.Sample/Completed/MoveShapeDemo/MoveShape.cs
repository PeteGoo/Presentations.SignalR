using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Sample.MoveShapeDemo.Backup {
    [HubName("moveShapeBackup")]
    public class MoveShapeHub2 : Hub {
        public void MoveShape(int x, int y) {
            Clients.AllExcept(Context.ConnectionId).shapeMoved(x, y);
        }
    }
}