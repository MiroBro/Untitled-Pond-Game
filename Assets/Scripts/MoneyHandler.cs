using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    private void Start()
    {
        References.Instance.uiHandler.RefreshMoney();
    }
    public void AddMoney(double amount)
    {
        StaticValues.money += amount;
        References.Instance.uiHandler.RefreshMoney();
    }
}
