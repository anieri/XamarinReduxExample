using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MapApp.Models;
using System.Collections.Immutable;
using MapApp.Store;
using MapApp.Actions;

namespace MapApp.ViewModels {
    public class TodoViewModel : BaseViewModel {
        public Command NewTodoCommand { get; private set; }

        public TodoViewModel() {
            App.Store.Subscribe<TodoState>(todo => this.Todos = todo.Todos);

            this.NewTodoCommand = new Command(this.AddTodo, () => !String.IsNullOrEmpty(this.NewText));
        }

        private void AddTodo() {
            App.Store.Dispatch(new AddTodoAction {
                Todo = new Todo {
                    Text = this.NewText,
                }
            });

            this.NewText = "";
        }

        private ImmutableList<Todo> todos;
        public ImmutableList<Todo> Todos {
            get { return this.todos; }
            set { this.SetProperty(ref this.todos, value); }
        }

        private String newText = "";
        public String NewText {
            get { return this.newText; }
            set { this.SetProperty(ref this.newText, value, onChanged: this.UpdateButton); }
        }

        private void UpdateButton() => this.NewTodoCommand.ChangeCanExecute();
    }
}
