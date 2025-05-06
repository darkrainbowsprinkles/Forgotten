using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Canvas pauseMenuCanvas;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    public static bool GameIsPaused = false;


    private void OnEnable()
    {
        inputReader.PauseEvent += HandlePause;

        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void OnDisable()
    {
        inputReader.PauseEvent -= HandlePause;

        resumeButton.onClick.RemoveListener(Resume);
        mainMenuButton.onClick.RemoveListener(LoadMainMenu);
    }

    private void HandlePause()
    {
        if(GameIsPaused) { Resume(); }
        else { Pause(); }
    }

    private void Pause()
    {
        GameIsPaused = true;

        EnableCursor();

        pauseMenuCanvas.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    private void Resume()
    {
        GameIsPaused = false;

        DisableCursor();

        pauseMenuCanvas.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }

    private void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
    }
}
