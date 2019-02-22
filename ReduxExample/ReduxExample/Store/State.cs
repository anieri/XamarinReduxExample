using ReduxExample.Actions;
using ReduxExample.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Text;

namespace ReduxExample.Store {
    public class State {
        public TodoState Todo { get; set; }
    }

    public class TodoState {
        public ObservableCollection<Todo> Todos { get; set; }
    }
}
