﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class MenuToggle : MonoBehaviour
{
    public VRTK_ControllerEvents controllerEvents;
    public GameObject menu;

    bool menuState = false;

    void OnEnable()
    {
        controllerEvents.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
    }

    void OnDisable()
    {
        controllerEvents.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;
    }


    private void ControllerEvents_ButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
    {
        menuState = !menuState;
        menu.SetActive(menuState);
    }

}
