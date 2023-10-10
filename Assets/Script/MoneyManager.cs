using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money;
    public TextMeshProUGUI moneyText;
    public Action onGetMoney;
    private float actualtimer;
    private float totalTimer = 1;
    private void Awake()
    {
        instance = this;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        onGetMoney?.Invoke();
    }

    private void Update()
    {
        if (actualtimer < totalTimer)
        {
            actualtimer += 1 * Time.deltaTime;
            if (actualtimer >= totalTimer)
            {
                actualtimer = 0;
                AddMoney(1);
            }
        }

        moneyText.text = "$" + money;
    }
}
