﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TypeWindown {GamePlay,StartGame,OverGame,Select,NextLevel,PopUpWin,PopUpLevel,PreviewLevel}
public class Windown : MonoBehaviour

   
{

   
    public TypeWindown type;
    public void Open()
    {
        
        Event_Open();
        gameObject.SetActive(true);
    }

    public void Close()
    {
        Event_Close();
        gameObject.SetActive(false);
    }

    public virtual void Event_Open()
    {

    }
    public virtual void Event_Close()
    {

    }

}
