using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ListaSupermercado : MonoBehaviour
{
    public List<string> productosEnElSuperMercado;
    public Dictionary<string, int> productos = new Dictionary<string, int>();
    public GameObject productInfoPrefab;
    public Transform scroll;
    

    private void Start()
    {
        foreach (string p in productosEnElSuperMercado)
        {
            productos.Add(p,Random.Range(10,20));
        }

        foreach (var p in productos)
        {
            GameObject go = Instantiate(productInfoPrefab, scroll);
            go.GetComponent<InfoProduct>().FillInfo(p.Key,p.Value);
        }
    }
}
