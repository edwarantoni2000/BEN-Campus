using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    public CharacterController controller;

    public float playerspeed = 10f;
    public float gravity = -9.81f;
    public static bool isSpeedZero; 

    Vector3 velocity;
    public bool freecam = false;



    [DllImport(dllName: "__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
    return IsMobile();
#endif
        return false;
    }

    private void EnableOrDisableJoystickBasedOnPlatform()
    {
        if (isMobile() == true) return;
        _joystick.gameObject.SetActive(false);
    }

    private void Start()
    {
        EnableOrDisableJoystickBasedOnPlatform();
    }

    void Update()
    {
        if (freecam == true)
        {
            freeCam();
        }
        else
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (isMobile() == true)
            {
                if (x == 0 && z == 0)
                {
                    x = _joystick.Horizontal;
                    z = _joystick.Vertical;
                }
            }

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * playerspeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        

    
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




    private void freeCam()
    {
        float movementSpeed = 10f;


        Cursor.visible = false;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
        {
            transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
        {
            transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
        }

    }


}
