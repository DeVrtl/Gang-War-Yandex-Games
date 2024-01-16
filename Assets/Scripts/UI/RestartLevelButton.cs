using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GangWar.UI
{
    [RequireComponent(typeof(Button))]
    public class RestartLevelButton : MonoBehaviour
    {
        private const string GameScene = "Game";

        private Button _button;

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

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnButtonClick()
        {
            SceneManager.LoadScene(GameScene);
        }
    }
}