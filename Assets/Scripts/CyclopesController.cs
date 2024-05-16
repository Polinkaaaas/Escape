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
    public AudioSource hitSound;
    public GameObject hitEffect;
    public GameObject deathEffect;
    public Transform hitEffectTransform;
    public Transform deathEffectTransform;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (hitEffectTransform == null) // Проверка, задан ли трансформ, если нет - используем основной
        {
            hitEffectTransform = transform;
        }
        if (deathEffectTransform == null) 
        {
            deathEffectTransform = transform;
        }
    }

    private void Update()
    {
        CheckDeath();
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

    private void CheckDeath() 
    
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, deathEffectTransform.position, deathEffectTransform.rotation);
            Instantiate(hitSound, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void PlayerAttackingCyclopes(int playerDamage)
    {
        if (playerController.GetAttackValue())
        {
            health -= playerDamage;
            playerController.SetAttackValue(false);
            Instantiate(hitEffect, hitEffectTransform.position, hitEffectTransform.rotation);
            Instantiate(hitSound, transform.position, transform.rotation);
        }
    }

}