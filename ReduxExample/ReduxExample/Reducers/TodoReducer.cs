using ReduxExample.Actions;
using ReduxExample.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxExample.Reducers {
    public static class TodoReducer {
        public static TodoState Reduce(TodoState prevState, ITodoAction todoAction) {
            if (todoAction is AddTodoAction addTodoAction) {
                return AddTodo(prevState, addTodoAction);
            }

            if (todoAction is RemoveTodoAction removeTodoAction) {
                return RemoveTodo(prevState, removeTodoAction);
            }

            return prevState;
        }

        private static TodoState AddTodo(TodoState prevState, AddTodoAction addTodoAction) {
            // In most cases it would make more sense to use an ImmutableList instead of the ObservableCollection
            // However, it seems that any change in the list would trigger a "render all" in Xamarin.
            // Thus, we are using the same reference to the ObservableCollection to add the item, returning a new TodoState.
            prevState.Todos.Add(addTodoAction.Todo);

            return new TodoState {
                Todos = prevState.Todos,
            };
        }

        private static TodoState RemoveTodo(TodoState prevState, RemoveTodoAction removeTodoAction) {
            // Same issue regarding ObservableCollection as above
            // And we are removing by reference, not looking up the id
            prevState.Todos.Remove(removeTodoAction.Todo);
            return new TodoState {
                Todos = prevState.Todos,
            };
        }
    }
}
