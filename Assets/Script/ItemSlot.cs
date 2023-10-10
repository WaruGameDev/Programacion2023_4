using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI nameItem, quantityItem;
    public Image iconItem;

    public void FillInfo(string itemName, string itemQuantity, Sprite icon)
    {
        nameItem.text = itemName;
        quantityItem.text = itemQuantity;
        iconItem.sprite = icon;
    }
}
