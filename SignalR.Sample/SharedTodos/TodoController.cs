using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Web.Http;

namespace SignalR.Sample.SharedTodos {
    public class TodoController : ApiController {
        private static readonly ConcurrentDictionary<string, Todo> todos = new ConcurrentDictionary<string, Todo>();

        public IEnumerable<Todo> Get() {
            return todos.Values;
        }

        public void Put(Todo todo) {
            todos.AddOrUpdate(todo.Description, i => todo, (i, todo1) => todo);
        }

        public void Post(Todo todo) {
            todos.AddOrUpdate(todo.Description, i => todo, (i, todo1) => todo);
        }
    }


    public class Todo {
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}