using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemBase> itemsPosibles;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public GameObject itemSlotPrefab;
    public Transform grid;

    private void Start()
    {
        Refresh();
    }

    public Sprite GetSprite(string item)
    {
        foreach (ItemBase i in itemsPosibles)
        {
            if (i.nameItem == item)
            {
                return i.icon;
            }
        }

        return null;
    }

    public void Refresh()
    {
        foreach (Transform child in grid)
        {
            Destroy(child.gameObject);
        }

        foreach (var i in inventory)
        {
            GameObject slot = Instantiate(itemSlotPrefab, grid);
            slot.GetComponent<ItemSlot>().
                FillInfo(i.Key,i.Value.ToString(), GetSprite(i.Key));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!inventory.ContainsKey("Manzana"))
            {
                inventory.Add("Manzana",1);
            }
            else
            {
                inventory["Manzana"] += 1;
            }
            Refresh();
        }
    }
}
