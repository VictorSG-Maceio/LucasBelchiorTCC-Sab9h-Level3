using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    Vector3 direction = new();
    Vector3 aux = new();
    public CharacterController body;
    public float speed = 1;
    public float gravity = 1;
    public bool jump;
    public float jumpSpeed = 1;



        
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal") * transform.right;  
        direction += Input.GetAxisRaw("Vertical") * transform.forward;
        jump = Input.GetAxisRaw("Jump") != 0;
    }
    private void FixedUpdate()
    { 
        aux.y -= gravity * Time.deltaTime;
        direction.y = aux.y;
        if (body.isGrounded) 
        {
            direction.y = 0;
            if (jump)
            {
                direction.y = jumpSpeed;
            }
            aux.y = direction.y;
        }
        body.Move(direction * speed * Time.deltaTime);
    }
}
