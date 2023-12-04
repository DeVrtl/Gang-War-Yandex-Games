using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

public class AuthorizationButton : MonoBehaviour
{
    [SerializeField] private Button _autorizeButton;
    [SerializeField] private GameObject _autorizeCard;

    private void OnEnable()
    {
        _autorizeButton.onClick.AddListener(OnAuthorizationButtonClick);
    }

    private void OnDisable()
    {
        _autorizeButton.onClick.RemoveListener(OnAuthorizationButtonClick);
    }

    private void OnAuthorizationButtonClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.Authorize();
        _autorizeCard.SetActive(false);
#endif
    }
}
