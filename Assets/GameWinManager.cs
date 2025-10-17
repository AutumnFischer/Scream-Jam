using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWinManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject winPanel;
    public TextMeshProUGUI winText;

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void PlayerWon()
    {
        Time.timeScale = 0f;
        if (winPanel != null)
            winPanel.SetActive(true);
        if (winText != null)
            winText.text = "YOU WIN!";
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
