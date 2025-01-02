using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private PlayerStateMachine _playerStateMachine;
    private ComboCharacter _comboCharacter;
    private Collider _capsuleCollider; // Reference to the capsule collider
    public int attackNumber;

    public float attackCooldown = 0.5f; // Time between attacks
    private float nextAttackTime = 0f; // Time when the next attack is allowed

    //new hitbox
    public LayerMask layermask;
    public Vector3 v3Knockback = new Vector3(50, 5, 0);

    //[SerializeField] 
    private float damage;

    [SerializeField] private HealthControler healthControler;

    private void Awake()
    {
        _playerStateMachine = GetComponentInParent<PlayerStateMachine>();
        _comboCharacter = GetComponentInParent<ComboCharacter>();
        _capsuleCollider = GetComponent<Collider>();
        _capsuleCollider.enabled = false;
        //if (_comboCharacter == null)
        //{
        //    Debug.LogError("ComboCharacter component not found!");
        //}
    }
    private void Update()
    {
        // If attack is pressed, enable the collider, otherwise disable it
            if (_comboCharacter._isAttackNPressed)
            {
                _capsuleCollider.enabled = true; // Enable collider when attacking
            }
            else
            {
                _capsuleCollider.enabled = false; // Disable collider when not attacking
            }
    }

    void OnTriggerEnter(Collider other)
    {
        //new hitbox
        if (layermask == (layermask | (1 << other.transform.gameObject.layer)))
        {
            Hurtbox h = other.GetComponent<Hurtbox>();
            if (h != null && Time.time >= nextAttackTime)
            {
                damage = _comboCharacter._AttackDmg;
                healthControler.takeDamage(damage);
                print("Enter - Attack hit");

                // Apply knockback using Rigidbody
                Rigidbody rb = h.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(v3Knockback, ForceMode.Impulse); // Apply knockback force
                }

                // Update the attack number with cooldown
                _comboCharacter._attackNumber++;

                if (_comboCharacter._attackNumber == 4)
                {
                    _comboCharacter._attackNumber = 1;
                }

                // Set the next attack time after the cooldown
                nextAttackTime = Time.time + attackCooldown;
            }
        }
        //normal left and right
        //    if (_comboCharacter != null && _comboCharacter._isAttackNPressed && _playerStateMachine._grounded) 
        //    {
        //        if (other.gameObject.tag == "AttackCol")
        //        {
        //            damage = _comboCharacter._AttackDmg;
        //            healthControler.takeDamage(damage);
        //            print("Enter - Attack hit");
        //            _comboCharacter._attackNumber++;
        //            if(_comboCharacter._attackNumber == 4)
        //            {
        //                _comboCharacter._attackNumber = 1; 
        //            }
        //            OnTriggerExit(other);
        //        }
        //        else
        //        {
        //            _comboCharacter._attackNumber = 1;
        //        }
        //    }
        //}

        //void OnTriggerStay(Collider other)
        //{

        //    if (layermask == (layermask | (1 << other.transform.gameObject.layer)))
        //    {
        //        if (_comboCharacter._attackNumber == 4)
        //        {
        //            _comboCharacter._attackNumber = 1;
        //        }
        //    }
        //}

        //new
        void OnTriggerExit(Collider other)
        {
            if (layermask == (layermask | (1 << other.transform.gameObject.layer)))
            {
                //if (_comboCharacter._attackNumber == 4)
                //{
                //    _comboCharacter._attackNumber = 1;
                //}
                print("Exit");
            }
        }
        //void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.tag == "AttackCol")
        //    {
        //        print("Exit");
        //    }
        //}
    }
}