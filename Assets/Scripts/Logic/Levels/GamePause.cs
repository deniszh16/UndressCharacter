using Logic.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Logic.Levels
{
    public class GamePause : MonoBehaviour
    {
        [Header("Кнопка паузы")]
        [SerializeField] private GameObject _pauseButton;
        
        [Header("Панель паузы")]
        [SerializeField] private GameObject _pausePanel;
        
        private StateMachine.StateMachine _stateMachine;
        
        [Inject]
        private void Construct(StateMachine.StateMachine stateMachine) =>
            _stateMachine = stateMachine;
        
        public void TogglePause(bool state)
        {
            if (state) _stateMachine.Enter<PauseState>();
            else _stateMachine.Enter<PlayState>();
        }
        
        public void ChangeButtonVisibility(bool visibility) =>
            _pauseButton.SetActive(visibility);

        public void ChangePausePanelVisibility(bool visibility) =>
            _pausePanel.SetActive(visibility);
    }
}