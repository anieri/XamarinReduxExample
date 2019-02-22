using ReduxExample.Actions;
using ReduxExample.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxExample.Reducers {
    public static class TodoReducer {
        public static TodoState Reduce(TodoState prevState, ITodoAction todoAction) {
            if (todoAction is AddTodoAction addTodoAction) {
                prevState.Todos.Add(addTodoAction.Todo);
                return new TodoState {
                    Todos = prevState.Todos,
                };
            }

            return prevState;
        }
    }
}
