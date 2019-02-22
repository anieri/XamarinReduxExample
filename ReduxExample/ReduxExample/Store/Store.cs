using ReduxExample.Actions;
using PubSub.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxExample.Store {
    public class Store {
        private readonly Hub hub = new Hub();

        private readonly Func<State, IAction, State> reducer;
        private State state;

        public Store(Func<State, IAction, State> reducer, State initialState) {
            this.reducer = reducer;
            this.state = initialState;
        }

        public void Subscribe<T>(Action<T> handler) {
            this.hub.Subscribe(handler: handler);
        }

        public void Dispatch<T>(T action) where T : IAction {
            this.state = this.reducer?.Invoke(this.state, action);

            // Publish changes
            // For now, it's recommended to check for equality, as it will publish for every action regardless of changes
            this.hub.Publish(data: this.state?.Todo);
        }
    }
}
