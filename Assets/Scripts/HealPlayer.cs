using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int healAmount = 1;
    public GameObject pickupEffect;
    public AudioSource pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HealPlayer(healAmount);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Instantiate(pickupSound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}