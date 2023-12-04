using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [field: SerializeField] public int HealthAmount;

    public event UnityAction<int> HealthChanged;

    protected virtual void CheackStatus()
    {
        if (HealthAmount <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void TakeDamage(int amount)
    {
        HealthAmount -= amount;

        HealthChanged?.Invoke(HealthAmount);

        CheackStatus();
    }
}
