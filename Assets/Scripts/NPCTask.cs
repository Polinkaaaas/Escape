using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTask : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Speech1;
    public QuestActivate QuestActivation;
    void Start()
    {
        
    }
    void Update()
    {
        if (EndDialog == true)
        {
            Time.timeScale = 1;
            QuestActivation.Quest1 = true;
            Speech1.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 0;
            Speech1. SetActive(true);
        }
    }
}
