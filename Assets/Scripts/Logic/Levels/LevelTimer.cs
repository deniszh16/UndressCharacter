using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.Levels
{
    public class LevelTimer : MonoBehaviour
    {
        [Header("Элементы таймера")]
        [SerializeField] private GameObject _timerContainer;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _timer;

        private int _seconds;
        private int _currentSeconds;
        private Coroutine _coroutine;

        public int CurrentSeconds =>
            _currentSeconds;

        public event Action TimerCompleted;

        public void SetTimer(int value)
        {
            _seconds = value;
            _currentSeconds = _seconds;
            UpdateTimerSlider();
        }

        public void ChangeTimerVisibility(bool state) =>
            _timerContainer.SetActive(state);

        public void StartTimer() =>
            _coroutine = StartCoroutine(StartTimerCoroutine());

        private IEnumerator StartTimerCoroutine()
        {
            WaitForSeconds seconds = new WaitForSeconds(1f);
            while (_currentSeconds > 0)
            {
                yield return seconds;
                _currentSeconds -= 1;
                UpdateTimerSlider();
            }
            
            TimerCompleted?.Invoke();
        }

        private void UpdateTimerSlider()
        {
            _slider.value = (float)_currentSeconds / _seconds;
            _timer.text = _currentSeconds.ToString();
        }

        public void StopTimer() =>
            StopCoroutine(_coroutine);
    }
}