using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Sample.MoveShapeDemo {
    [HubName("moveShape")]
    public class MoveShapeHub : Hub {
        public void MoveShape(int x, int y) {
            Clients.AllExcept(Context.ConnectionId).shapeMoved(x, y);
        }
    }
}