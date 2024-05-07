using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator playerAnimator;
    
    // Start is called before the first frame update
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
