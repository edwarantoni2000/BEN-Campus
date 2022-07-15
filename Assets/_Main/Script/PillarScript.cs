using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarScript : MonoBehaviour
{
    public GameObject[] pillar;

    
    // Start is called before the first frame update
    public void Start()
    {
        pillar = GameObject.FindGameObjectsWithTag("peler");
        foreach (GameObject wi in pillar)
        {
            wi.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
}
