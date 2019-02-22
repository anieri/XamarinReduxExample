using ReduxExample.Actions;
using ReduxExample.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxExample.Reducers {
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
