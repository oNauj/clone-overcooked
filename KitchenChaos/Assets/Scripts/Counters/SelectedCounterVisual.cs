using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameobjectArray;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        foreach (GameObject visualGameObjet in visualGameobjectArray)
        {
            visualGameObjet.SetActive(false);
        }
    }

    private void Show()
    {
        foreach (GameObject visualGameObjet in visualGameobjectArray)
        {
            visualGameObjet.SetActive(true);
        }
    }
}
