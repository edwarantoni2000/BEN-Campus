using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdwarMouseTap : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;
    public static bool isTouched;

    public Transform PlayerBody;
    float xRotation = 0f;
    bool Paused = false;
    private Vector3 rotateValue;




    private void Start()
    {

    }
    void Update()
    {
        float  mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }



    //public void setTouchedFalse()
    //{
    //    isTouched = false;
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.Confined;
    //    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    //}



}
