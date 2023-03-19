using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
     private Animator animator;
    [SerializeField] private const string OPEN_CLOSE = "OpenClose";

    [SerializeField] private ContainerCounter containerCounter;

    private void Awake() {
        animator = this.GetComponent<Animator>();
        
    }

    private void Start() 
    {
        containerCounter.OnPlayerGrabbedObject += ContainerOpenClose_OnPlayerGrabbedObject;
    }
    private void ContainerOpenClose_OnPlayerGrabbedObject(object sender, EventArgs e)
    {
        animator.SetBool(OPEN_CLOSE, true);
    }
}
