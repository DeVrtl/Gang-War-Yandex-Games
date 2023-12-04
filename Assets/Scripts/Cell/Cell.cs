using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CellHover))]
public class Cell : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private ObjectPool _granadePool;
    [SerializeField] private ObjectPool _shotgunBullet;
    [SerializeField] private ToggleSound _toggleSound;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private GameObject _playCard;
    [SerializeField] private GameObject _miscCard;
    [SerializeField] private GameInitiator _game;
    [SerializeField] private Transform _point;

    private CellHover _hover;

    public bool IsCellOccupied { get; private set; } = false;

    public event UnityAction CellReleased;
    public event UnityAction CellOccupied;

    private void Awake()
    {
        _hover = GetComponent<CellHover>();
    }

    private void OnMouseDown()
    {
        if (_hover.UnitInCell == null || IsCellOccupied == true)
            return;

        _hover.SwitchToStandartMaterial();

        _playButton.gameObject.SetActive(true);

        _hover.UnitInCell.FollowMouse.enabled = false;
        _hover.UnitInCell.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        _hover.UnitInCell.Move.SetTarget(_point);
        _hover.UnitInCell.AssignCell(this);

        _game.UnitAnimators.Add(_hover.UnitInCell.Animator);
        _game.UnitMoveForwards.Add(_hover.UnitInCell.Move);
        _game.UnitShooters.Add(_hover.UnitInCell.Shooter);

        _toggleSound.AudioSources.Add(_hover.UnitInCell.Shooter.Source);
        _toggleSound.AudioSources.Add(_hover.UnitInCell.SpawnedHandler.Source);

        switch (_hover.UnitInCell.Class)
        {
            case UnitClass.SMG:
                _hover.UnitInCell.Shooter.SetPool(_bulletPool);
                break;

            case UnitClass.Shotgun:
                _hover.UnitInCell.Shooter.SetPool(_shotgunBullet);
                break;

            case UnitClass.GranadeLauncher:
                _hover.UnitInCell.Shooter.SetPool(_granadePool);
                break;
        }

        _hover.DisableCollider();

        IsCellOccupied = true;
        CellOccupied?.Invoke();

        _playCard.SetActive(true);
        _miscCard.SetActive(true);
    }

    public void FreeCell()
    {
        IsCellOccupied = false;
        CellReleased?.Invoke();
    }
}
