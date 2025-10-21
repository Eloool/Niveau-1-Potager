using TMPro;
using UnityEngine;

public class PorteMonnaie : MonoBehaviour
{
    private int money = 1000;
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
        this.money += money;
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
}
