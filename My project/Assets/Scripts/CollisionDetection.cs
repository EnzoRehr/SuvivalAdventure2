using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Shovel wc;
    public  float Damage =50f;   


        private void OnTriggerEnter(Collider other)
        {
        if(other.CompareTag("Enemy") && wc.IsAttacking && wc.CanDealDamage )
        {
            Debug.Log("Enemy Hit");
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(Damage);
            }
            wc.CanDealDamage = false;
        }
        }

    
}
