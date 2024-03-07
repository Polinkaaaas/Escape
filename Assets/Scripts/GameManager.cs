using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentKeys;
    public int totalKeys;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI doorText;
    public GameObject door;
    public GameObject[] boxes; 
    public float openTime = 25f; // время в секундах, на которое открывается дверь

    public void AddKeys(int keysToAdd)
    {
        if (currentKeys == 1)
        {
            doorText.text = "Door is open!";
            keysText.gameObject.SetActive(false);
            door.SetActive(false);
            StartCoroutine(CloseDoor(openTime));
        }
        else
            currentKeys -= keysToAdd;
        keysText.text = string.Format("{0} / {1}", currentKeys, totalKeys);
        
    }

    IEnumerator CloseDoor(float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < boxes.Length; i++) 
        {
            boxes[i].SetActive(true); // установка каждого объекта в состояние активного
        }
        keysText.gameObject.SetActive(true);
        doorText.text = "";
    }
}

