using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private const string CUT = "Cut";

    [SerializeField] private CuttingCounter cuttingCounter;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }
    private void CuttingCounter_OnCut(object sender, EventArgs e)
    {
        animator.SetBool(CUT, true);
    }
}
