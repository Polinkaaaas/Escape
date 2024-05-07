using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class AttackStateMachine : StateMachineBehaviour
{
    private GameObject player;
    private float beginPoint = 0.0f;
    private bool isNextPlaying;
    private bool check = true;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        beginPoint = Time.time;
        check = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (check)
        {
            isNextPlaying = (Time.time - beginPoint) > stateInfo.length / 2.0f;
            if (isNextPlaying)
            {
                player.gameObject.GetComponent<PlayerController>().AttackTrue();
                beginPoint = Time.time;
                check = false;
            }
        }
        else
        {
            isNextPlaying = (Time.time - beginPoint) > stateInfo.length;
            if (isNextPlaying)
            {
                player.gameObject.GetComponent<PlayerController>().AttackTrue();
                beginPoint = Time.time;
            }
        }

        if (Time.time >= stateInfo.length)
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
