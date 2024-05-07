using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CyclopesController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private bool isInPlayerTrigger = false;
    
    public int health = 100;
    
    public int damageToGive = 1;
    public AudioSource hurtSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {   
       PlayerAttackingCyclopes(playerController.playerDamage);
       Debug.Log(Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x));
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
            Instantiate(hurtSound, transform.position, transform.rotation);
        }
    }

    private void PlayerAttackingCyclopes(int playerDamage)
    {
        if (playerController.isAttacking && Vector3.Distance(this.gameObject.transform.position, player.transform.position) <=2.0f)
        {
            health -= playerDamage;
            playerController.isAttacking = false;
        }
    }

    public void SetIsInPlayerTrigger(bool value)
    {
        isInPlayerTrigger = value;
    }
}
