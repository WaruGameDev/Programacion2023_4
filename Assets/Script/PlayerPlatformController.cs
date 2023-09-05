using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    //posiciones para detectar si el personaje esta en el piso
    public Transform groundCheck, groundCheckLeft, groundCheckRight;
    public Rigidbody2D rb;// rigidbody componente encargado de las físicas
    public bool isGround; //booleano para colocar si estamos en el piso o no
    public LayerMask ground; //recordar usar la layer asignada al piso
    public float detectRadius = .2f; //radio de deteccion de las esderas del piso
    public float speedPlayer = 10, jumpPlayer = 10, 
        lowMultiplierJump = 2, fallMultiplierJump =2.5f; // valores para las propiedades del jugador

    public bool canMove = true;
    private void Update()
    {
        //detectar usando la funcion IsGrounded para saber si al menos una de las 3 esfera toca el piso
        isGround = IsGrounded(groundCheck) 
                   || IsGrounded(groundCheckLeft) 
                   || IsGrounded(groundCheckRight);
        if (canMove)
        {
            float x = Input.GetAxis("Horizontal"); //obtener el input horizontal dejado por el input manager
            rb.velocity = new Vector2(x * speedPlayer, rb.velocity.y); // modificamos el velocity para mover horizontalmente el personaje
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplierJump -1) * Time.deltaTime);
            }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowMultiplierJump -1) * Time.deltaTime);
            }
            if (Input.GetButtonDown("Jump") && isGround) // detectamos si el personaje esta en el piso y apretamos saltar
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.velocity += jumpPlayer * Vector2.up;//modificamos el rigidbody para impulsar el personaje hacia arriba
            }
        }
        

    }
// usamos esta funcion con un raycas circle para detectar si esta en el piso el transform.
    bool IsGrounded(Transform check)
    {
        return Physics2D.OverlapCircle(check.position, detectRadius,ground);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, detectRadius);
        Gizmos.DrawWireSphere(groundCheckLeft.position, detectRadius);
        Gizmos.DrawWireSphere(groundCheckRight.position, detectRadius);
    }
}
