using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider), typeof(Button))]

public class ObjectClick : MonoBehaviour
{
   
    public bool isCube1Destroy= true;

    public GameObject cube;
    public bool isCube2Aktive = true;
    public GameObject cube2;
 

    private Material m_Mat;
    
    public bool isWinGame = true;
    public bool isPopUpActive = true;


    [SerializeField] RectTransform _PopUp;
    public bool isChangeColorActive = true;
    [SerializeField]  public Material m_MouseOverColor;
    [SerializeField] public Material m_OriginalColor;
    [SerializeField] public Material m_OriginalColor2;

    MeshRenderer m_Renderer;
    //[SerializeField] List<GameObject> Trash = new List<GameObject>();


 

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
        m_OriginalColor2 = m_Renderer.material;
    }

  



    public void OnMouseOver()
    {
        if(isChangeColorActive == true)
        {
            m_Renderer.material = m_MouseOverColor;
        }
        
   
        
    }

    public void OnMouseExit()
    {
        m_Renderer.material = m_OriginalColor;
        m_Renderer.material = m_OriginalColor2;
    }


    private void OnMouseDown()

        {

        if (isCube2Aktive == true)
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
