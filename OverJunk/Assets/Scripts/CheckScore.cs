using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckScore : MonoBehaviour
{
    public int scoreNeeded = 28;
    public string sceneToLoad = "Final";
    public TextMeshProUGUI infoText; // Reference to the TextMeshPro component
    public float displayDuration = 10.0f; // Time duration for displaying the text

    private bool isDisplaying = false;
    private float displayTimer = 0f;

    private void Start()
    {
        if (infoText == null)
        {
            Debug.LogError("Please assign the TextMeshPro component to 'infoText'");
        }
        else
        {
            infoText.gameObject.SetActive(false); // Initially hide the text
        }
    }

    private void Update()
    {
        if (isDisplaying)
        {
            displayTimer += Time.deltaTime;

            if (displayTimer >= displayDuration)
            {
                isDisplaying = false;
                displayTimer = 0f;
                infoText.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int score = ScoreSystem.Instance.GetScore(); // Access score from ScoreSystem
            if (score >= scoreNeeded)
            {
                LoadScene();
            }
            else
            {
                DisplayInfoText("pegue todas as moedas");
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    void DisplayInfoText(string message)
    {
        if (infoText != null && !isDisplaying)
        {
            infoText.text = message;
            infoText.gameObject.SetActive(true);
            isDisplaying = true;
        }
    }
}
