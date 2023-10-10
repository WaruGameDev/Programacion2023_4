using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InfoProduct : MonoBehaviour
{
    public TextMeshProUGUI nombreProducto, prizeProducto;
    public int prize;
    public Button buyButton;

    private void Start()
    {
        MoneyManager.instance.onGetMoney += CanBuy;
        CanBuy();
    }

    public void CanBuy()
    {
        if (MoneyManager.instance.money >= prize)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    public void FillInfo(string productName, int productPrize)
    {
        nombreProducto.text = productName;
        prizeProducto.text = "$" + productPrize;
        prize = productPrize;
    }
}
