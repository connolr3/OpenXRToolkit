using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//required to read input

public class AnimateHandOnInput : MonoBehaviour
{
    // Start is called before the first frame update

    public InputActionProperty pinchAnimationAction;
    public Animator handAnimator;

    public InputActionProperty gripAnimationAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();//read in input of trigger buttin. use bool for an activte that gives 0 or 1. use float as we are reading in any value from 0 to 1.
        handAnimator.SetFloat("Trigger",triggerValue);//pass to animator

        float gripValue = gripAnimationAction.action.ReadValue<float>();//READ IN FLOAT VALUE
        handAnimator.SetFloat("Grip", gripValue);//pass to animator

    }
}
