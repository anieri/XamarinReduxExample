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
            this.state = initialState ?? throw new ArgumentNullException("initialState cannot be null");
        }

        public void Subscribe<T>(Action<T> handler) {
            this.hub.Subscribe(handler: handler);
        }

        public void Dispatch<T>(T action) where T : IAction {
            State prevState = this.state;
            this.state = this.reducer?.Invoke(prevState, action);

            // Publish changes to the State objects.
            // This only does a shallow compare, you should do a deep compare inside the Subscribed method.
            if (prevState.Todo != this.state.Todo) {
                this.hub.Publish(data: this.state.Todo);
            }
        }
    }
}
