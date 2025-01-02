using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockBackState : MonoBehaviour
{
    public float KnockBackForce;
    public float KnockBackTime;
    private float KnockBackCounter;

    void Update()
    {
        if (KnockBackCounter <= 0)
        {
            //movement
        }
        else
            KnockBackCounter -= Time.deltaTime;
    }
    public void Knockback(Vector3 direction)
    {
        KnockBackCounter = KnockBackTime;

        //moveDirection = direction * KnockBackForce;
    }
}
