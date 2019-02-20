using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MapApp.Models;
using System.Collections.Immutable;
using MapApp.Store;

namespace MapApp.ViewModels {
    public class TodoViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public TodoViewModel() {
            App.Store.Subscribe<TodoState>(todo => this.Todos = todo.Todos);
        }

        private ImmutableList<Todo> todos;
        public ImmutableList<Todo> Todos {
            get { return this.todos; }
            set { this.SetProperty(ref this.todos, value); }
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
