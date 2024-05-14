using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator playerAnimator;
    
    void Start()
    {
        playerController.PlayerAttacking += PlayerAttacking;
    }

    private void PlayerAttacking()
    {
        playerAnimator.SetBool("isAttacking", true);
    }

    public void PlayerAttackingFalse()
    {
        playerAnimator.SetBool("isAttacking", false);
    }
}
