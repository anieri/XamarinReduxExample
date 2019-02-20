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
    public class TodoViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

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
            set { this.SetProperty(ref this.newText, value, "NewText", () => this.NewTodoCommand.ChangeCanExecute()); }
        }

        #region INotify Boilerplate
        public Boolean SetProperty<T>(ref T backingStore, T value, [CallerMemberName]String propertyName = "", Action onChanged = null) {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            this.OnPropertyChanged(propertyName);
            return true;
        }

        public void OnPropertyChanged([CallerMemberName] String propertyName = "") {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
