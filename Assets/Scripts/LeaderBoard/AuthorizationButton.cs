using UnityEngine.UI;
using Agava.YandexGames;
using UnityEngine;

namespace GangWar.LeaderBoard
{
    public class AuthorizationButton : MonoBehaviour
    {
        [SerializeField] private Button _autorizeButton;
        [SerializeField] private GameObject _autorizeCard;

        private void OnEnable()
        {
            AddListener();
        }

        private void OnDisable()
        {
            RemoveListener();
        }

        private void AddListener()
        {
            _autorizeButton.onClick.AddListener(OnAuthorizationButtonClick);
        }

        private void RemoveListener()
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
}