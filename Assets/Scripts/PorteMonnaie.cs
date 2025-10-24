using TMPro;
using UnityEngine;

public class PorteMonnaie : MonoBehaviour
{
    [SerializeField] private int money = 0;
    private int multiplicateur = 1;
    public static PorteMonnaie instance;
    public TextMeshProUGUI meshPro;

    private void Awake()
    {
        instance = this;
        ChangeMoney();
    }

    public int getMoney()
    {
        return money;
    }

    public void addMoney(int money)
    {
        this.money += money * multiplicateur;
        ChangeMoney();
    }

    private void ChangeMoney()
    {
        meshPro.text = "Argent : " + money.ToString();
    }

    public bool RemoveMoney( int moneyNeeded)
    {
        if (money >= moneyNeeded)
        {
            money -= moneyNeeded;
            ChangeMoney();
            return true;
        }
        return false;
    }
    public void SetMultiplicateur(int multiplicateur)
    {
        this.multiplicateur = multiplicateur;
    }
}
