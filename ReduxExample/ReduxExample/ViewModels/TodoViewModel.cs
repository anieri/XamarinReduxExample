using System;
using Xamarin.Forms;
using ReduxExample.Models;
using ReduxExample.Store;
using ReduxExample.Actions;
using System.Collections.ObjectModel;

namespace ReduxExample.ViewModels {
    public class TodoViewModel : BaseViewModel {
        public Command NewTodoCommand { get; private set; }
        public Command RemoveTodoCommand { get; private set; }

        public TodoViewModel() {
            App.Store.Subscribe<TodoState>(todo => this.Todos = todo.Todos);

            this.NewTodoCommand = new Command(this.AddTodo, () => !String.IsNullOrEmpty(this.NewText));
            this.RemoveTodoCommand = new Command(this.RemoveTodo);
        }

        private void RemoveTodo(Object arg) {
            App.Store.Dispatch(new RemoveTodoAction {
                Todo = arg as Todo,
            });
        }

        private void AddTodo() {
            App.Store.Dispatch(new AddTodoAction {
                Todo = new Todo {
                    Text = this.NewText,
                }
            });

            this.NewText = "";
        }

        private ObservableCollection<Todo> todos;
        public ObservableCollection<Todo> Todos {
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
