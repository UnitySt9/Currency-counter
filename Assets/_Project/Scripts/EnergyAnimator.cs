using System.Collections;
using UnityEngine;

namespace _Project.Scripts
{
    public class EnergyAnimator : CurrencyAnimator
    {
        private void Start()
        {
            _minAmount = 1;
            _maxAmount = 25;
            base.Start();
        }
    
        protected override void OnCollectButtonClicked()
        {
            int amount = Random.Range(_minAmount, _maxAmount + 1);
            StartCoroutine(AnimateEnergyCoroutine(amount));
        }
    
        protected override void AnimateCurrencyCollection(int amount)
        {
            // Реализация в корутине
        }
    
        private IEnumerator AnimateEnergyCoroutine(int amount)
        {
            int iconsCount = Mathf.Clamp(amount, 1, 5);
        
            for (int i = 0; i < iconsCount; i++)
            {
                RectTransform icon = Instantiate(_currencyIconPrefab, _collectButton.transform);
                StartCoroutine(AnimateSingleEnergy(icon, i * 0.2f));
            }
        
            FindObjectOfType<CurrencyController>().AddEnergy(amount);
            yield return null;
        }
    
        private IEnumerator AnimateSingleEnergy(RectTransform icon, float delay)
        {
            yield return new WaitForSeconds(delay * _animationDuration);
        
            Vector3 startPos = icon.position;
            Vector3 endPos = _targetPosition.position;
            float progress = 0f;
            float spiralRadius = 50f;
        
            while (progress < 1f)
            {
                progress += Time.deltaTime / _animationDuration;
            
                // Спиральное движение
                float angle = progress * 4f * Mathf.PI;
                float currentRadius = spiralRadius * (1f - progress);
                Vector3 spiralOffset = new Vector3(
                    Mathf.Cos(angle) * currentRadius,
                    Mathf.Sin(angle) * currentRadius,
                    0
                );
            
                icon.position = Vector3.Lerp(startPos, endPos, progress) + spiralOffset;
            
                // Пульсация масштаба
                float scale = 0.5f + Mathf.Abs(Mathf.Sin(progress * 8f)) * 0.5f;
                icon.localScale = Vector3.one * scale;
            
                yield return null;
            }
        
            Destroy(icon.gameObject);
        }
    }
}