using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.LeaderBoard
{
    public class LeaderboardButton : MonoBehaviour
    {
        [SerializeField] private GameObject _authoriseCard;
        [SerializeField] private GameObject _miscCard;
        [SerializeField] private LeaderboardFiller _board;
        [SerializeField] private Button _button;

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
            _button.onClick.AddListener(OnButtonClick);
        }

        private void RemoveListener()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized == true)
        {
            _board.gameObject.SetActive(true);
            _miscCard.SetActive(false);
        }
        else
        {
            _authoriseCard.SetActive(true);
            _miscCard.SetActive(false);
        }
#endif
        }
    }
}