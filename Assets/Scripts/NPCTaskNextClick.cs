using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTaskNextClick : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    private bool isText1 = true;
    public NPCTask npcTaskScript;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isText1 == true) {
                isText1 = false;
            }
            else
            {
                isText1 = true;
                npcTaskScript.EndDialog = true;
            }
        }
        if (isText1 == true)
        {
            Text1. SetActive(true);
            Text2.SetActive(false);
        }
        else
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
        }
        {
            
        }
    }
}
