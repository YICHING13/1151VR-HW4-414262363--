
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public bool isGameOver = false;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

     public void AddScore()
    {
        if (isGameOver) return;
            score++;

        if (GameAudio.Instance != null)
            GameAudio.Instance.PlaySuccess();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("GAME OVER! Score: " + score);

        if (GameAudio.Instance != null)
        GameAudio.Instance.PlayCrash();

        Time.timeScale = 0f;
    }

    void OnGUI()
    {
        GUIStyle scoreStyle = new GUIStyle(GUI.skin.label);
        scoreStyle.fontSize = 32;
        scoreStyle.fontStyle = FontStyle.Bold;
        scoreStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(20, 20, 300, 50),
            "Score: " + score, scoreStyle);

        if (!isGameOver) return;

        float centerX = Screen.width / 2f;
        float centerY = Screen.height / 2f;

        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        titleStyle.fontSize = 48;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.normal.textColor = Color.red;

        GUI.Label(
            new Rect(centerX - 200, centerY - 110, 400, 70),
            "GAME OVER",
            titleStyle
        );

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 24;

        if (GUI.Button(
            new Rect(centerX - 100, centerY + 10, 200, 60),
            "RESTART",
            buttonStyle))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
