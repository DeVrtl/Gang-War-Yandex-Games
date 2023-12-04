using UnityEngine;

[RequireComponent(typeof(ParticleSystemFollow))]
public class ParticleSystemHandler : MonoBehaviour
{
    [field: SerializeField] public AudioSource Source;

    [SerializeField] private ParticleSystem _effect;

    private UnitHealth _health;
    private ParticleSystemFollow _follow;

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void Awake()
    {
        _follow = GetComponent<ParticleSystemFollow>();
    }

    private void Start()
    {
        _health.Died += OnDied;
    }

    private void OnDied()
    {
        _follow.enabled = false;

        _effect.Play();
        Source.Play();
    }

    public void Initialize(UnitHealth health, Unit unit)
    {
        _health = health;
        _follow.SetTarget(unit);
    }
}
