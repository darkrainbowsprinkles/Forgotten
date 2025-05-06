using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthPresenter : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Button reloadButton;
    [SerializeField] Button mainMenuButton;

    [SerializeField] float enableCursorDelay;

    private PauseMenu pauseMenu;

    void OnEnable()
    {
        reloadButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);

        playerHealth.onHealthChange += UpdateHealthBar;
        playerHealth.onPlayerDead += ShowGameOverCanvas;
    }


    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }

    void ShowGameOverCanvas()
    {
        pauseMenu.enabled = false;

        StartCoroutine(EnableUI());
        
        gameOverCanvas.gameObject.SetActive(true);
    }

    IEnumerator EnableUI()
    {
        yield return new WaitForSeconds(enableCursorDelay);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        reloadButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

}
