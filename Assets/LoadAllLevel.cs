using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAllLevel : MonoBehaviour
{
    public void LoadStart()
    {
        //  int i = 0;
        var a =  transform.GetComponentsInChildren<Level>();
        //foreach (var level in a)
        //{
        //    level.gameObject.transform.position = new Vector3(0, level.gameObject.transform.position.y, 0);
        //      level.gameObject.SetActive(false);

        //}
        foreach (var level in a)
        {

            level.SetUp();
        }

        //int x = 10;
        //int y = 0;
        //for (int i = 0; i < a.Length; i++)
        //{
        //    if (i % 10 == 0)
        //    {
        //        y += 20;

        //    }
        //    float posx = x * i;

        //    a[i].transform.position = new Vector3(posx, a[i].transform.position.y, y);
        //}

    }
    }
