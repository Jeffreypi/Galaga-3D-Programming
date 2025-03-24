using TMPro;
using UnityEngine;

public class GlobalScoreManager : MonoBehaviour
{
    public static GlobalScoreManager Instance; // Singleton instance

    [SerializeField] private TextMeshProUGUI _scoreText;

    private int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Ensure only one instance exists
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep across scenes
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (_scoreText != null)
        {
            _scoreText.text = score.ToString("D4"); // Format as "Score: 0001"
        }
    }

    public int GetScore()
    {
        return score;
    }
}
