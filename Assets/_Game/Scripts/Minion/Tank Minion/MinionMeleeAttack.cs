using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMeleeAttack : MonoBehaviour
{
    [SerializeField] float timeForAttack = 0.5f;
    [SerializeField] GameObject shield = default;
    [SerializeField] float timeForUseUlti = 5f;

    private bool canAttack = true;
    private float timeOfLastAttack;
    private Animator minionAttackAnimation;
    private bool sidePunchAnimation = false;

    private float timeOfLastUlti;

    private bool canUseUlti = true;

    private void Start()
    {
        minionAttackAnimation = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                if (Time.time > timeOfLastAttack)
                {
                    if (sidePunchAnimation)
                    {
                        minionAttackAnimation.SetTrigger("LeftPunch");
                        sidePunchAnimation = false;
                    }
                    else
                    {
                        minionAttackAnimation.SetTrigger("Golpe");
                        sidePunchAnimation = true;
                    }

                    timeOfLastAttack = Time.time + timeForAttack;

                }

            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Shield(true);
            canAttack = false;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            Shield(false);
            canAttack = true;
        }

        if(Input.GetKeyDown("space"))
        {
            if (canUseUlti)
            {
                Ulti();
            }
        }

        TimeUpToUseUlti();
    }

    private void Shield(bool value)
    {
        shield.SetActive(value);
    }

    private void Ulti()
    {
        Debug.Log("Hulk Aplasta");
        canUseUlti = false;
        timeOfLastUlti = timeForUseUlti;
    }

    private void TimeUpToUseUlti()
    {
        if(timeOfLastUlti > 0 && !canUseUlti)
        {
            timeOfLastUlti -= Time.deltaTime;
        }
        else
        {
            canUseUlti = true;
        }
    }
}
