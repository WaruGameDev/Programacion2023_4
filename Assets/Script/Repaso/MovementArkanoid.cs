using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArkanoid : MonoBehaviour
{
    public float speedPlayer = 20;
    public float limit = 8;
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * (x * speedPlayer * Time.deltaTime));
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limit, limit);
        transform.position = pos;
    }
}
