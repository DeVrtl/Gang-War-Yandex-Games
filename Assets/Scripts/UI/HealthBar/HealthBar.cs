using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slider.maxValue = _health.HealthAmount;
        _slider.value = _health.HealthAmount;
    }

    private void OnHealthChanged(int health)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, health, _speed * Time.deltaTime);
    }
}
