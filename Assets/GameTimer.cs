using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeLimit = 90f;
    private float timeRemaining;

    [Header("UI Display")]
    public TextMeshProUGUI timerText;

    void Start()
    {
        timeRemaining = timeLimit;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0f)
            timeRemaining = 0f;

        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(timeRemaining);
            timerText.text = "Time: " + seconds.ToString();
        }

        if (timeRemaining <= 0f)
        {
            Debug.Log("Time's up! Player died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
