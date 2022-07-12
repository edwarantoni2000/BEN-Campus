using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  

    public CharacterController controller;

    public float playerspeed = 0f;
    public float gravity = -9.81f;
    public static bool isSpeedZero; 

    Vector3 velocity;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerspeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    
    }

    public void setMoveZero()
    {
        isSpeedZero = false;
        playerspeed = 4f;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * playerspeed * Time.deltaTime);
    }
}
