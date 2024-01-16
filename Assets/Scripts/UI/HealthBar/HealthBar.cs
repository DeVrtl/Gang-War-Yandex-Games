using GangWar.BattleSystem;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.UI.HealthBar
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Slider _slider;
        [SerializeField] private float _speed;

        private void OnEnable()
        {
            Subcribe();
        }

        private void OnDisable()
        {
            UnSubcribe();
        }

        private void Start()
        {
            AssignSliderValue();
        }

        private void Subcribe()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void UnSubcribe()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void AssignSliderValue()
        {
            _slider.maxValue = _health.HealthAmount;
            _slider.value = _health.HealthAmount;
        }

        private void OnHealthChanged(int health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speed * Time.deltaTime);
        }
    }
}