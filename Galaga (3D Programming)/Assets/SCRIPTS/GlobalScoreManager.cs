using TMPro;
using UnityEngine;

public class GlobalScoreManager : MonoBehaviour
{
    public static GlobalScoreManager Instance; // Singleton instance

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _healthText;

    private int score = 0;
    private int health = 4; // Starting health

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
        UpdateHealthUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void DecreaseHealth(int amount = 1)
    {
        health = Mathf.Max(0, health - amount); // Clamp to 0
        UpdateHealthUI();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

    private void UpdateScoreUI()
    {
        if (_scoreText != null)
        {
            _scoreText.text = score.ToString("D4");
        }
    }

    private void UpdateHealthUI()
    {
        if (_healthText != null)
        {
            _healthText.text = $"{health}";
        }
    }
}
