using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class setBoolBehaviour : StateMachineBehaviour
{
    public string boolParameterName;
    public bool updateOnstate;
    public bool updateOnStateMachine;
    public bool valueOnEnter;
    public bool valueOnExit;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnstate)
        {
            animator.SetBool(boolParameterName, valueOnEnter);
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnstate)
        {
            animator.SetBool(AttN, valueOnExit);
        }
        animator.SetFloat(AttN, 0);
    }


    //OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (updateOnStateMachine)
        {
            animator.SetBool(boolParameterName, valueOnEnter);
        }
    }

    //OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (updateOnStateMachine)
        {
            animator.SetBool(boolParameterName, valueOnExit);
        }
    }
}
