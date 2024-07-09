using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteCollisionDetection : MonoBehaviour
{
    public float Damage=20f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.LogWarning("Player Hit");
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}