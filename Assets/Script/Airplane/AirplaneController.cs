using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float playerSpeed = 15;
    public float yawAmount = 120;
    public bool isInverted = true;
    private float yaw;
    private float pitch;
    private float roll;
    public ParticleSystem waterParticles;
    private Rigidbody rb;
    private void Update()
    {
        //mover hacia adelante
        transform.position += transform.forward * (playerSpeed * Time.deltaTime);
        //input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (!isInverted)
        {
            y *= -1;
        }
        //doblar
        yaw += yawAmount * Time.deltaTime * x;
        pitch = Mathf.Lerp(0, 20, Mathf.Abs(y)) * Mathf.Sign(y);
        roll  = Mathf.Lerp(0, 30, Mathf.Abs(x)) * -Mathf.Sign(x);
        
        
        transform.localRotation = 
            Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);

        Ray r = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(r, out var hit, 3))
        {
            waterParticles.transform.position = hit.point + new Vector3(0,.5f,0);
            if(!waterParticles.isPlaying)
                waterParticles.Play();
        }
        else
        {
            if (!waterParticles.isStopped)
            {
                waterParticles.Stop();
            }
        }
    }
}
