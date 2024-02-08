using UnityEngine;

namespace Logic.UI
{
    public class ElementAdaptability : MonoBehaviour
    {
        [Header("Ссылки на компоненты")]
        [SerializeField] private RectTransform _rectTransform;
        
        [Header("Активность")]
        [SerializeField] private bool _activity;
        
        [Header("Позиция и размер")]
        [SerializeField] private Vector2 _wideScreenPosition;
        [SerializeField] private Vector2 _ultraWideScreenPosition;

        private void Start()
        {
            if (!_activity) return;
            switch (AspectRatio.Ratio)
            {
                case > 1.8f and <= 2f:
                    _rectTransform.localPosition = _wideScreenPosition;
                    return;
                case > 2f:
                    _rectTransform.localPosition = _ultraWideScreenPosition;
                    break;
            }
        }
    }
}