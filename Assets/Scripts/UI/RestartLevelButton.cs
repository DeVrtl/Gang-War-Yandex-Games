using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartLevelButton : MonoBehaviour
{
    private const string GameScene = "Game";

    private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnButtonClick);
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
