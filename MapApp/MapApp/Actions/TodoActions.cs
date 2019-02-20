using MapApp.Models;
using PubSub.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp.Actions {
    public interface ITodoAction : IAction { }

    public class AddTodoAction : ITodoAction {
        public Todo Todo { get; set; }
    }
}
