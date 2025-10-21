using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public static Score instance;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textMultiplcateur;
    private int multiplicateur = 1;

    private void Start()
    {
        instance = this;
        ChangeScore();
        ChangeMultiplicateur();
    }

    public int getScore()
    {
        return score;
    }

    public void addScore(int score)
    {
        this.score += score * multiplicateur;
        ChangeScore();
    }

    private void ChangeScore()
    {
        textScore.text = "Score : "+ score.ToString();
    }

    private void ChangeMultiplicateur()
    {
        textMultiplcateur.text = "Multiplicateur : *" + this.multiplicateur.ToString();
    }

    public void SetMultiplicateur(int multiplicateur)
    {
        this.multiplicateur = multiplicateur;
        ChangeMultiplicateur();
    }

    public int getMultiplicateur()
    {
        return multiplicateur;
    }
}
