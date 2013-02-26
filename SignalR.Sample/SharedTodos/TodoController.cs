using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.SignalR;


namespace SignalR.Sample.SharedTodos {
    public class TodoController : ApiController {
        private static readonly ConcurrentDictionary<string, Todo> todos = new ConcurrentDictionary<string, Todo>();

        public IEnumerable<Todo> Get() {
            return todos.Values;
        }

        public void Post(Todo todo) {
            todos.AddOrUpdate(todo.Description, i => {
                Notify(string.Format("The todo item '{0}' was added", todo.Description));
                return todo;
            }, 
            (i, todo1) => {
                if (todo1.Done != todo.Done) {
                    Notify(string.Format("The todo item '{0}' was marked as {1}", todo1.Description,
                                         todo.Done ? "Done" : "Incomplete"));
                }
                return todo;
            });
        }

        public void Delete(Todo todo) {
            Todo removed;
            todos.TryRemove(todo.Description, out removed);
            if (removed != null) {
                Notify(string.Format("The todo item '{0}' was removed", todo.Description));
            }
        }

        private void Notify(string message) {
            GlobalHost.ConnectionManager.GetConnectionContext<TodoNotificationConnection>()
                      .Connection.Broadcast(message);
        }
    }

    public class Todo {
        public string Description { get; set; }
        public bool Done { get; set; }
    }

    
}