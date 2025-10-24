using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    public class CurrencyController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private TextMeshProUGUI _diamondText;
        [SerializeField] private TextMeshProUGUI _energyText;
    
        private int _goldAmount = 0;
        private int _diamondAmount = 0;
        private int _energyAmount = 0;
    
        public void AddGold(int amount)
        {
            _goldAmount += amount;
            UpdateUI();
        }
    
        public void AddDiamonds(int amount)
        {
            _diamondAmount += amount;
            UpdateUI();
        }
    
        public void AddEnergy(int amount)
        {
            _energyAmount += amount;
            UpdateUI();
        }
    
        private void UpdateUI()
        {
            _goldText.text = _goldAmount.ToString();
            _diamondText.text = _diamondAmount.ToString();
            _energyText.text = _energyAmount.ToString();
        }
    }
}