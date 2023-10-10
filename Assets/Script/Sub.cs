using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sub : MonoBehaviour
{
    public bool suscrito;

    public void Move()
    {
        transform.DOShakePosition(1);
    }

    private void OnMouseDown()
    {
        if (suscrito)
        {
            ParentEvent.instance.onPressButton -= Move;
            suscrito = false;
        }
        else if(!suscrito)
        {
            ParentEvent.instance.onPressButton += Move;
            suscrito = true;
        }
    }
}
