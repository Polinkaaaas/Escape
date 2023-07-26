using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestActivate : MonoBehaviour
{
    public GameObject Text;
    public GameObject KeysCollection;
    public bool Quest1 = false;
    
    void Update()
    {
        if (Quest1 == true)
        {
            Text.SetActive(true);
            KeysCollection.SetActive(true);
        }
        else
        {
            Text.SetActive(false);
            KeysCollection.SetActive(false);
        }
    }
}
