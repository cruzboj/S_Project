using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public LayerMask layermask;
    //ComboCharacter _comboCharacter;
    [SerializeField] public float damage = 10f;
    public PlayerStateMachine playerMovment;
    [SerializeField] private HealthControler healthControler;

    //private void Start()
    //{
    //    // Get the ComboCharacter component from the parent GameObject
    //    _comboCharacter = GetComponentInParent<ComboCharacter>();

    //    // Check if _comboCharacter was found before assigning damage
    //    if (_comboCharacter != null)
    //    {
    //        damage = _comboCharacter._AttackDmg;
    //    }
    //    else
    //    {
    //        Debug.LogError("ComboCharacter component not found in parent hierarchy.");
    //    }
    //}

    //private void OnParticleTrigger(Collider collision)
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (layermask == (layermask | (1 << other.transform.gameObject.layer)))
        {
            //https://www.youtube.com/watch?v=0u2R9MDi-_w
            //send knockback to statemachine where is movment controls placed
            playerMovment.KBCounter = playerMovment.KBTotalTime;
            if(other.transform.position.x <= transform.position.x)
            {
                playerMovment.KnockFromRight = true;
            }
            if (other.transform.position.x > transform.position.x)
            {
                playerMovment.KnockFromRight = false;
            }
            //send dmg to health ui
            healthControler.takeDamage(damage);
        }
    }
}
