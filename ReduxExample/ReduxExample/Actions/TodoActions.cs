using ReduxExample.Models;
using PubSub.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxExample.Actions {
    public interface ITodoAction : IAction { }

    public class AddTodoAction : ITodoAction {
        public Todo Todo { get; set; }
    }
}
