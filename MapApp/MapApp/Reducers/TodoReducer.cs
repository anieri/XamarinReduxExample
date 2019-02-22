using MapApp.Actions;
using MapApp.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp.Reducers {
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
