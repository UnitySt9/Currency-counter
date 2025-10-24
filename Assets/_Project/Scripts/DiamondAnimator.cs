using System.Collections;
using UnityEngine;

namespace _Project.Scripts
{
    public class DiamondAnimator : CurrencyAnimator
    {
        private void Start()
        {
            _minAmount = 10;
            _maxAmount = 100;
            base.Start();
        }
    
        protected override void OnCollectButtonClicked()
        {
            int amount = Random.Range(_minAmount, _maxAmount + 1);
            StartCoroutine(AnimateDiamondsCoroutine(amount));
        }
    
        protected override void AnimateCurrencyCollection(int amount)
        {
            // Реализация в корутине
        }
    
        private IEnumerator AnimateDiamondsCoroutine(int amount)
        {
            int iconsCount = Mathf.Clamp(amount / 10, 2, 8);
        
            for (int i = 0; i < iconsCount; i++)
            {
                RectTransform icon = Instantiate(_currencyIconPrefab, _collectButton.transform);
                icon.localScale = Vector3.zero;
            
                // Прямолинейная анимация
                StartCoroutine(AnimateSingleDiamond(icon, i * 0.1f));
            }
        
            FindObjectOfType<CurrencyController>().AddDiamonds(amount);
            yield return null;
        }
    
        private IEnumerator AnimateSingleDiamond(RectTransform icon, float delay)
        {
            yield return new WaitForSeconds(delay * _animationDuration);
        
            Vector3 startPos = icon.position;
            Vector3 endPos = _targetPosition.position;
            float progress = 0f;
        
            // Анимация появления
            while (progress < 1f)
            {
                progress += Time.deltaTime / (0.3f * _animationDuration);
                icon.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, progress);
                yield return null;
            }
        
            progress = 0f;
        
            // Анимация перемещения
            while (progress < 1f)
            {
                progress += Time.deltaTime / _animationDuration;
                icon.position = Vector3.Lerp(startPos, endPos, progress);
            
                // Добавляем небольшое дрожание для эффекта бриллиантов
                icon.Rotate(0, 0, Mathf.Sin(progress * 20f) * 2f);
            
                yield return null;
            }
        
            // Анимация исчезновения
            progress = 0f;
            while (progress < 1f)
            {
                progress += Time.deltaTime / (0.2f * _animationDuration);
                icon.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, progress);
                yield return null;
            }
        
            Destroy(icon.gameObject);
        }
    }
}