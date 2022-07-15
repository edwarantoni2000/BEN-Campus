using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider), typeof(Button))]

public class ObjectClick : MonoBehaviour
{
   
    public bool isCube1Destroy= true;

    public GameObject cube;
    public bool isCube2Active = true;
    public GameObject cube2;

    public bool isCube3Active = false;
    public GameObject cube3;

    public bool isCube4Active = false;
    public GameObject cube4;
 

    private Material m_Mat;
    
    public bool isWinGame = true;
    public bool isPopUpActive = true;


    [SerializeField] RectTransform _PopUp;
    public bool isChangeColorActive = true;
    [SerializeField]  public Material m_MouseOverColor;
    [SerializeField] public Material m_OriginalColor;
 

    MeshRenderer m_Renderer;
    MeshRenderer m_Rotating;
    

    public bool isAnimating = false;

    public Animator anim;
    [SerializeField] public Material m_MouseColorRotating;


    private void OnEnable()
    {
        m_Mat = transform.GetComponent<Renderer>()?.material;
    }

    private void OnMouseUpAsButton()
    {
        if(isPopUpActive == true)
        {
            _PopUp.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MouseLook.isTouched = true;
            Debug.Log("Clicked");
        }

    }

    private void Start()
    {
        

        Cursor.visible = true;
        m_Renderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_Renderer.material;

        m_Rotating = GetComponent<MeshRenderer>();

    
    }

  



    public void OnMouseOver()
    {
        if (isAnimating == true)
        {
            anim.GetComponent<Animator>().enabled = true;
            
            m_Rotating.material = m_MouseColorRotating;
        }
        if (isCube4Active == true)
        {
            cube4.gameObject.SetActive(true);
           
        } 

        if (isCube3Active == true)
        {
            cube3.gameObject.SetActive(true);
          
        } 

        if (isChangeColorActive == true)
        {
            m_Renderer.material = m_MouseOverColor;
        }
        
 

        
    }


    public void OnMouseExit()
    {
        cube3.SetActive(false);
        cube4.SetActive(false);

        m_Renderer.material = m_OriginalColor;
    }


    private void OnMouseDown()

        {
 

        if (isCube2Active == true)
        {

            cube2.gameObject.SetActive(true);
        } 

        if (isCube1Destroy == true)
        {
           Destroy(cube);
        } if (isWinGame == true)
        {
            Time.timeScale = 0f;
           
        }


    }

    public void setGameResume()
    {
        Time.timeScale = 1f;
        
    }







    // Update is called once per frame
}
