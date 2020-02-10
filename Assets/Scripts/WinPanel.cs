using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;

    [SerializeField]
    private Text yourScoreText, bestScoreText;

    [SerializeField]
    private Button nextLevelButton, exitButton;

    // Start is called before the first frame update
    private void Start()
    {
        root.gameObject.SetActive(false);

        nextLevelButton.onClick.AddListener(OnNextLevelClick);
        exitButton.onClick.AddListener(OnExitClick);
    }

    public void SetPanelActive(bool state)
    {
        root.gameObject.SetActive(state);
    }

    public void SetScoreText(int score)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScore = score;
        }

        yourScoreText.text = "Score: " + score.ToString();
        bestScoreText.text = "Best score: " + bestScore;
    }

    private void OnNextLevelClick()
    {
        SceneManager.LoadScene(2);
    }
    private void OnExitClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        nextLevelButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }
}
