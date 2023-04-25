using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int currentKeys;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI doorText;
    public GameObject door;
   
    void Start()
    {
    }


    void Update()
    {
        
    }

    public void AddKeys(int keysToAdd)
    {
        if (currentKeys == 1)
        {
            doorText.text = "Door is open!";
            keysText.gameObject.SetActive(false);
            door.SetActive(false);
        }
        else
            currentKeys -= keysToAdd;
        keysText.text = " " + currentKeys;
    }
}

