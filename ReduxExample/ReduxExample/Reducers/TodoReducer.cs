using ReduxExample.Actions;
using ReduxExample.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxExample.Reducers {
    public static class TodoReducer {
        public static TodoState Reduce(TodoState prevState, ITodoAction todoAction) {
            if (todoAction is AddTodoAction addTodoAction) {
                // In most cases it would make more sense to use an ImmutableList instead of the ObservableCollection
                // However, it seems that any change in the list would trigger a "render all" in Xamarin.
                // Thus, we are using the same reference to the ObservableCollection to add the item, returning a new TodoState.
                prevState.Todos.Add(addTodoAction.Todo);
                return new TodoState {
                    Todos = prevState.Todos,
                };
            }

            return prevState;
        }
    }
}
