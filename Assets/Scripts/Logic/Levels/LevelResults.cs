using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Logic.Levels
{
    public class LevelResults : MonoBehaviour
    {
        [Header("Панель победы")]
        [SerializeField] private GameObject _victoryPanel;
        [SerializeField] private ParticleSystem _confettiEffect;
        [SerializeField] private Button _doubleButton;
        [SerializeField] private TextMeshProUGUI _characterUnlocked;

        public event Action RewardIncreased;
        
        [Header("Панель поражения")]
        [SerializeField] private GameObject _lossPanel;

        private void OnEnable() =>
            _doubleButton.onClick.AddListener(DoubleYourReward);

        public void ShowVictoryPanel() =>
            _ = StartCoroutine(ShowVictoryPanelCoroutine());

        private IEnumerator ShowVictoryPanelCoroutine()
        {
            yield return new WaitForSeconds(1.2f);
            _victoryPanel.SetActive(true);
            _confettiEffect.gameObject.SetActive(true);
            _confettiEffect.Play();
        }

        private void DoubleYourReward()
        {
            _doubleButton.interactable = false;
            RewardIncreased?.Invoke();
        }

        public void ShowCharacterUnlock()
        {
            _doubleButton.gameObject.SetActive(false);
            _characterUnlocked.gameObject.SetActive(true);
        }

        public void ShowLossPanel(bool visibility) =>
            _lossPanel.SetActive(visibility);

        private void OnDisable() =>
            _doubleButton.onClick.RemoveListener(DoubleYourReward);

        private void OnDestroy() =>
            RewardIncreased = null;
    }
}