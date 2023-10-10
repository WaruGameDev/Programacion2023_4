using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 0)]
public class ItemBase : ScriptableObject
{
    public string nameItem;
    public string description;
    public int prize;
    public Sprite icon;
}
