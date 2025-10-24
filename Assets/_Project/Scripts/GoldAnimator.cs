using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts
{
    public class GoldAnimator : CurrencyAnimator
    {
        private void Start()
        {
            _minAmount = 100;
            _maxAmount = 1000;
            base.Start();
        }
    
        protected override void OnCollectButtonClicked()
        {
            int amount = Random.Range(_minAmount, _maxAmount + 1);
            AnimateCurrencyCollection(amount);
        }
    
        protected override void AnimateCurrencyCollection(int amount)
        {
            int iconsCount = Mathf.Clamp(amount / 100, 3, 10);
        
            for (int i = 0; i < iconsCount; i++)
            {
                RectTransform icon = Instantiate(_currencyIconPrefab, _collectButton.transform);
                icon.localScale = Vector3.zero;
            
                // DOTween анимация
                Sequence sequence = DOTween.Sequence();
            
                // Появление с эффектом
                sequence.Append(icon.DOScale(Vector3.one, 0.3f * _animationDuration)
                    .SetEase(Ease.OutBack));
            
                // Перемещение к цели с параболой
                Vector3 randomOffset = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0);
                Vector3 midPoint = (_collectButton.transform.position + _targetPosition.position) / 2 + 
                                   Vector3.up * 200f + randomOffset;
            
                sequence.Append(icon.DOPath(
                        new Vector3[] { icon.position, midPoint, _targetPosition.position },
                        _animationDuration, PathType.CatmullRom)
                    .SetEase(Ease.InOutCubic));
            
                // Исчезновение при достижении цели
                sequence.Append(icon.DOScale(Vector3.zero, 0.2f * _animationDuration)
                    .SetEase(Ease.InBack));
            
                sequence.OnComplete(() => Destroy(icon.gameObject));
            
                // Применяем масштаб времени от слайдера
                sequence.timeScale = _speedSlider.value;
            }
        
            // Уведомляем контроллер о получении валюты
            FindObjectOfType<CurrencyController>().AddGold(amount);
        }
    }
}