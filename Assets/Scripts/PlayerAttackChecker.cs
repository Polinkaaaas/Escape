using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackChecker : MonoBehaviour
{
    private CyclopesController cyclopesParent;
    private PlayerController player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        cyclopesParent = this.gameObject.GetComponentInParent<CyclopesController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cyclopesParent.PlayerAttackingCyclopes(player.playerDamage);
        }
    }
}
