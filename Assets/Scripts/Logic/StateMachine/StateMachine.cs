using System;
using System.Collections.Generic;
using Logic.StateMachine.States;

namespace Logic.StateMachine
{
    public class StateMachine
    {
        private IState ActiveState { get; set; }
        private Dictionary<Type, IState> _states;
        
        public StateMachine() =>
            _states = new Dictionary<Type, IState>();

        public void AddState<TState>(TState state) where TState : class, IState =>
            _states.Add(typeof(TState), state);

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state?.Enter();
        }

        private IState ChangeState<TState>() where TState : class, IState
        {
            ActiveState?.Exit();
            
            TState state = GetState<TState>();
            ActiveState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;
    }
}