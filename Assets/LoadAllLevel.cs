using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAllLevel : MonoBehaviour
{
    public void LoadStart()
    {
        var a =  transform.GetComponentsInChildren<Level>();
        foreach(var level in a)
        {
            level.SetUp();
        }
    }
}
