using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score = 0;

    // Singleton instance
    private static ScoreSystem instance;

    public static ScoreSystem Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public int GetScore()
    {
        return score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
