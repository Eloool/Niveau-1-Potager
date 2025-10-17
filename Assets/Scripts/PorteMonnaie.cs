using TMPro;
using UnityEngine;

public class PorteMonnaie : MonoBehaviour
{
    private int money = 0;
    public static PorteMonnaie instance;
    public TextMeshProUGUI meshPro;

    private void Start()
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

    public bool RemoveMoney(int money, int moneyNeeded)
    {
        if (money > moneyNeeded)
        {
            money -= moneyNeeded;
            ChangeMoney();
            return true;
        }
        return false;
    }
}
