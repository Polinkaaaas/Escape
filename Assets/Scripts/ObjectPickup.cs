using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public int value;
    public GameObject pickupEffect;
    public AudioSource pickupSound;
   
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().AddKeys(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Instantiate(pickupSound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
