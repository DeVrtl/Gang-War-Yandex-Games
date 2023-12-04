using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Unit))]
public class UnitHealth : Health
{
    [SerializeField] private HealthBarFader _fader;

    private Unit _unit;

    public event UnityAction Died;

    private void Awake()
    {
        _unit = GetComponent<Unit>();   
    }

    protected override void CheackStatus()
    {
        if (HealthAmount <= 0)
        {
            gameObject.SetActive(false);
            _unit.MyCell.FreeCell();
            Died?.Invoke();
        }
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);

        _fader.FadeIn();
    }
}
