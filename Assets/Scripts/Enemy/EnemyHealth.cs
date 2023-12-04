using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private AudioSource Source;
    [SerializeField] private ParticleSystem DeathEffect;
    [SerializeField] private Money _money;

    private void OnDisable()
    {
        DeathEffect.Play();
        Source.Play();
    }

    protected override void CheackStatus()
    {
        if (HealthAmount <= 0)
        {
            gameObject.SetActive(false);
            _money.gameObject.SetActive(true);
        }
    }
}
