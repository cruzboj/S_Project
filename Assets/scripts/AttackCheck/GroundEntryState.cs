using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = _comboCharacter._attackNumber;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);

        // Set the attack damage using the correct property
        if(_comboCharacter._attackNumber == 1)
            _comboCharacter._AttackDmg = _comboCharacter.AttackDmg1;
        if (_comboCharacter._attackNumber == 2)
            _comboCharacter._AttackDmg = _comboCharacter.AttackDmg2;
        if (_comboCharacter._attackNumber == 3)
            _comboCharacter._AttackDmg = _comboCharacter.AttackDmg3;
        //Debug.Log("Player Attack " + attackIndex + " Fired!");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new GroundComboState());
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}
