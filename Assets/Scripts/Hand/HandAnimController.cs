using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimController : MonoBehaviour
{
    [SerializeField] private InputActionReference gripInputAction;
    [SerializeField] private InputActionReference triggerInputAction;

    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gripInputAction.action.performed += GripPressed;
        triggerInputAction.action.performed += TriggerPressed;
    }

    private void OnDisable()
    {
        gripInputAction.action.performed -= GripPressed;
        triggerInputAction.action.performed -= TriggerPressed;
    }

    private void TriggerPressed(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

   
}
