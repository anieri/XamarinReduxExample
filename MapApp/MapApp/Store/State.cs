using MapApp.Actions;
using MapApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MapApp.Store {
    public class State {
        public TodoState Todo { get; set; }
    }

    public class TodoState {
        public ImmutableList<Todo> Todos { get; set; }
    }
}
