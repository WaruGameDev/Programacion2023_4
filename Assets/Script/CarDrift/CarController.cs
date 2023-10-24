using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speedCar = 50;
    public float drag = .98f;
    public float maxSpeed = 20;
    public float steering = 20;
    public float traction = 1;
    public float bodyTilt = 20;
    public Transform carbody;
    public Vector3 moveForce;
    public AudioSource music;
    public TrailRenderer[] trails;
    
    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        moveForce += transform.forward * (speedCar * y * Time.deltaTime);
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        transform.position += moveForce * Time.deltaTime;
        
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * (x * steering * Time.deltaTime * moveForce.magnitude));

        float roll = Mathf.Lerp(0, bodyTilt, Mathf.Abs(x)) * Mathf.Sign(x);
        carbody.localRotation = Quaternion.Euler(Vector3.forward * roll);

        Debug.DrawRay(transform.position, moveForce.normalized * 3, Color.blue);
        Debug.DrawRay(transform.position, transform.forward *3 , Color.red);
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
        if (Vector3.Angle(moveForce.normalized, transform.forward) > 10 && moveForce.magnitude > 10)
        {
            maxSpeed = 60;
            music.volume = Mathf.MoveTowards(music.volume, 1, Time.deltaTime);
            foreach (TrailRenderer t in trails)
            {
                t.emitting = true;
            }
            
        }
        else
        {
            maxSpeed = 100;
            music.volume = Mathf.MoveTowards(music.volume, 0.25f, Time.deltaTime);
            foreach (TrailRenderer t in trails)
            {
                t.emitting = false;
            }
        }
        
       

    }
}
