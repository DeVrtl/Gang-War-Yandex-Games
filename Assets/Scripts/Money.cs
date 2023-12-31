using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshCollider))]
public class Money : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private ParticleSystem _pickUpEffect;
    [SerializeField] private int _reward;

    private MeshRenderer _renderer;
    private MeshCollider _collider;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<MeshCollider>();
    }

    public void AddTo(PlayerWallet wallet)
    {
        wallet.AddMoney(_reward);

        _pickUpEffect.Play();
        _source.Play();

        _renderer.enabled = false;
        _collider.enabled = false;
    }
}
