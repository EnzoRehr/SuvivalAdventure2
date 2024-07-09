using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public GameObject shovel;
    public bool CanAttack = true;
    public float AttackCooldown = 1.5f;
    public bool IsAttacking = false;

    public bool CanDealDamage=false;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(CanAttack)
            {
                ShovelAttack();
               
            }
        }
    }

    public void ShovelAttack()
    {
       
        IsAttacking = true;
        CanAttack = false;
        Animator anim = shovel.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetDamageBool());
        StartCoroutine(ResetAttackCooldown());
    }


    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
       
    }

    IEnumerator ResetDamageBool()
    {
        yield return new WaitForSeconds(0.55f);
        CanDealDamage = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(AttackCooldown);
        IsAttacking = false;
    }

}
