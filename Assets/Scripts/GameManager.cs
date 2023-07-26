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
    public GameObject[] boxes; // массив объектов
    public float openTime = 15f; // время в секундах, на которое открывается дверь

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
        keysText.text = " " + currentKeys;
    }

    IEnumerator CloseDoor(float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < boxes.Length; i++) // цикл для прохода по списку объектов
        {
            boxes[i].SetActive(true); // установка каждого объекта в состояние активного
        }
        keysText.gameObject.SetActive(true);
        doorText.text = "";
    }
}

