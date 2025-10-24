using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public abstract class CurrencyAnimator : MonoBehaviour
    {
        [SerializeField] protected RectTransform _currencyIconPrefab;
        [SerializeField] protected RectTransform _targetPosition;
        [SerializeField] protected Button _collectButton;
        [SerializeField] protected Slider _speedSlider;
    
        protected float _animationDuration = 1.0f;
        protected int _minAmount;
        protected int _maxAmount;
    
        protected virtual void Start()
        {
            _collectButton.onClick.AddListener(OnCollectButtonClicked);
            _speedSlider.onValueChanged.AddListener(OnSpeedChanged);
            _speedSlider.minValue = 0f;
            _speedSlider.maxValue = 3f;
            _speedSlider.value = 1f;
        }
    
        protected abstract void OnCollectButtonClicked();
    
        protected virtual void OnSpeedChanged(float speed)
        {
            _animationDuration = 1.0f / Mathf.Max(speed, 0.1f);
        }
    
        protected abstract void AnimateCurrencyCollection(int amount);
    }
}