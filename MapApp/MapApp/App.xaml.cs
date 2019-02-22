using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapApp.Views;
using MapApp.Store;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MapApp {
    public partial class App : Application {

        private static readonly State initialState = new State {
            Todo = new TodoState {
                Todos = new ObservableCollection<Models.Todo>(),
            },
        };

        public static Store.Store Store = new Store.Store(Reducers.Reducer.Reduce, initialState);

        public App() {
            InitializeComponent();

            MainPage = new HomePage();
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
