using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UnitFollowMouse), typeof(UnitAnimator), typeof(UnitMove))]
[RequireComponent(typeof(Shooter), typeof(UnitHealth))]
public class Unit : MonoBehaviour
{
    [field: SerializeField] public UnitClass Class;

    [SerializeField] private ParticleSystemHandler _particleSystemHandler;

    public ParticleSystemHandler SpawnedHandler { get; private set; }
    public Cell MyCell { get; private set; }
    public UnitHealth UnitHealt { get; private set; }
    public UnitFollowMouse FollowMouse { get; private set; }
    public UnitAnimator Animator { get; private set; }
    public UnitMove Move { get; private set; }
    public Shooter Shooter { get; private set; }

    private void Awake()
    {
        FollowMouse = GetComponent<UnitFollowMouse>();
        UnitHealt = GetComponent<UnitHealth>();
        Animator = GetComponent<UnitAnimator>();
        Move = GetComponent<UnitMove>();
        Shooter = GetComponent<Shooter>();

        ParticleSystemHandler instance = Instantiate(_particleSystemHandler);
        instance.Initialize(UnitHealt ,this);
        SpawnedHandler = instance;
    }

    public void AssignCell(Cell cell)
    {
        MyCell = cell;
    }
}
