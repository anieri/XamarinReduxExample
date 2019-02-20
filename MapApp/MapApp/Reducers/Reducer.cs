using MapApp.Actions;
using MapApp.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp.Reducers {
    public static class Reducer {
        public static State Reduce(State prevState, IAction action) {
            if (action is ITodoAction todoAction) {
                return new State {
                    Todo = TodoReducer.Reduce(prevState.Todo, todoAction),
                };
            }

            return prevState;
        }
    }
}
