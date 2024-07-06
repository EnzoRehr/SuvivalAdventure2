using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Shovel wc;
       


        private void OnTriggerEnter(Collider other)
        {
        if( other.tag== "Enemy" && wc.IsAttacking )
        {
            Debug.Log("Enemy Hit");
            
        }
        }

    
}
