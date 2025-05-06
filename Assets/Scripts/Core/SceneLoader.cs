using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button mainMenuButton;

    private int currentSceneIndex;

    private void OnEnable()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        reloadButton.onClick.AddListener(ReloadScene);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        
    }

    private void OnDisable()
    {
        reloadButton.onClick.AddListener(ReloadScene);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);

        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
    }
}
