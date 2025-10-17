using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public static Score instance;
    public TextMeshProUGUI meshPro;

    private void Start()
    {
        instance = this;
        ChangeScore();
    }

    public int getScore()
    {
        return score;
    }

    public void addScore(int score)
    {
        this.score += score;
        ChangeScore();
    }

    private void ChangeScore()
    {
        meshPro.text = "Score : "+ score.ToString();
    }
}
