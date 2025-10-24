using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public static Score instance;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textMultiplcateur;
    private int multiplicateur = 1;
    [SerializeField ] private int maxScore = 100;

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
        if(this.score >= maxScore && !MenuStart.instance.IsInfinite())
        {
            MenuGame.Instance.AfficherFin();
        }
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
