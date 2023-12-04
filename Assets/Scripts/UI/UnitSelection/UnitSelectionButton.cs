using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitSelectionButton : MonoBehaviour
{
    [field: SerializeField] public Unit Unit;

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _unitButton;

    private GameObject _background;

    private void OnEnable()
    {
        _unitButton.onClick.AddListener(OnUnitButtonClick);
    }

    private void OnDisable()
    {
        _unitButton.onClick.RemoveListener(OnUnitButtonClick);
    }

    private void OnUnitButtonClick()
    {
        Instantiate(Unit.gameObject);

        _background.SetActive(false);
    }

    public void SetBackground(GameObject background)
    {
        _background = background;
    }

    public void GenerateUnit(string description, Sprite unitIcon, Unit unit)
    {
        _description.text = description;
        _icon.sprite = unitIcon;
        Unit = unit;
    }
}
