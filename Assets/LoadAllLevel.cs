using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAllLevel : MonoBehaviour
{
    
    public void LoadStart()
    {

       // var a = GameObject.Find("GameMananger").GetComponent<GamePlayCtrl>().LevesGame;
        //var gameCtrl = GameObject.Find("GameMananger").GetComponent<GamePlayCtrl>();
        // var b = Reset(a);
        //gameCtrl.LevesGame = b;
        //  Sort(a);
        //  Sort1(a);
        //int i = 0;
        var a =  transform.GetComponentsInChildren<Level>();



        //foreach (var level in a)
        //{
        //    level.gameObject.transform.position = new Vector3(0, level.gameObject.transform.position.y, 0);
        //    level.gameObject.SetActive(false);

        //}
        foreach (var level in a)
        {

            level.SetUp();
        }

        //int x = 10;
        //int y = 0;
        //for (int i = 0; i < a.Count; i++)
        //{
        //    if (i % 10 == 0)
        //    {
        //        y += 20;

        //    }
        //    float posx = x * i;

        //    a[i].transform.position = new Vector3(posx, a[i].transform.position.y, y);
        //    a[i].transform.position = new Vector3(0, a[i].gameObject.transform.position.y, 0);
        //   a[i].gameObject.SetActive(false);
        //}

    }

    public void Sort(List<Level> list)
    {
        int index = -1;
        for (int i=0;i<list.Count-1;i++)
        {
            index++;
            for(int j=i+1;j<list.Count;j++)
            {
                string x = list[i].transform.name.Trim();
                string y = list[j].transform.name.Trim();
                x = x.Replace("Level ", "");
                x = x.Trim();
                y = y.Replace("Level ", "");
                y = y.Trim();
                int x1;
              //  Debug.Log(x +"  "+ y);
                if(!int.TryParse(x, out x1))
                {
                    continue;
                }
                int y1;
                if(!int.TryParse(y, out y1))
                {
                    continue;
                }

              

            
                if (x1 > y1)
                {
                    Level level;
                    level = list[i];
                    list[i] = list[j];
                    list[j] = level;
                   // Swap(list[i].transform, list[j].transform,index);
                }
            }
            
        }
    }

    public List<Level> Reset(List<Level> list)
    {
        List<Level> newList = new List<Level>();
        foreach (var level in list)
        {
            if (level == null)

            continue;
            newList.Add(level);
        }
       
        return newList;
    }
    private void Swap(Transform tran1,Transform tran2,int index)
    {
      
       
        tran2.SetSiblingIndex(index);

    }

    public void Sort1(List<Level> list)
    {
        int index = 1;
        for (int i=0;i<list.Count;i++)
        {
           
            list[i].level = index;
            index++;
            string x = list[i].transform.name.Trim();
         
               x = x.Replace("Level ", "");
                x = x.Trim();

                int x1;
            
                if(!int.TryParse(x, out x1))
                {

            }
            else
            {
                list[i].transform.SetSiblingIndex(i);
            }
             
        }
    }
    }
