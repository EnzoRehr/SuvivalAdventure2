using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealth : BaseEnemyHealth
{
   
   

    protected override void Start()
    {
        base.Start();
        
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        
        Howl();
    }

    protected override void Die()
    {
        base.Die();
        
        Debug.Log("Wolf has died.");
        Transform rootTransform = transform.root; 
        rootTransform.gameObject.SetActive(false);
    }

    private void Howl()
    {
        Debug.Log("Wolf howls in response to taking damage!");
       
    }
}
