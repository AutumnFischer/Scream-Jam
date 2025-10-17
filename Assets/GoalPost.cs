using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPost : MonoBehaviour
{
    [Header("UI & Audio References")]
    public GameObject winPanel;         
    public MusicManager musicManager;     
    private bool hasWon = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasWon && collision.CompareTag("Player"))
        {
            hasWon = true;
            if (musicManager != null)
            {
                musicManager.StopMusic(); 
            }

            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }

            Time.timeScale = 0f; 
        }
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
