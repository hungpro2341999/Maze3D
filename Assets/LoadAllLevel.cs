using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAllLevel : MonoBehaviour
{
    public void LoadStart()
    {
        int i = 0;
        var a =  transform.GetComponentsInChildren<Level>();
        foreach (var level in a)
        {
          //  level.gameObject.SetActive(false);
            
        }
        foreach (var level in a)
        {

            level.SetUp();
        }



    }
}
