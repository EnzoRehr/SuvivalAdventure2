using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketCollectorHealth : BaseEnemyHealth
{
    protected override void Start()
    {
        base.Start();

    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);

        Scream();
    }

    protected override void Die()
    {
        base.Die();

        Debug.Log("TicketCollector has died.");
        Transform rootTransform = transform.root;
        rootTransform.gameObject.SetActive(false);
    }

    private void Scream()
    {
        Debug.Log("TicketCollector screams in pain");

    }
}

