using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Diamond : Item
{
    
    public SpriteRenderer Img;
    public int id;
    public float speed;
    public bool ActiveKey = false;
    public void ChangeColor()
    {
        Img.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }

    public void ChangeColorFailer()
    {
        Img.color = new Color(0, 0, 0, 1);
    }

    public override void ResetItem()
    {
        Img.color = new Color(1,1,1,1);
    }

    private void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += speed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
    public override void ActiveItemTriger(BallControlScript ball)
    {

        if (ActiveKey)  
            return;

        if(id == LockGem.CountUnGem)
        {
            LockGem.CountUnGem += 1;
            ChangeColor();
            ActiveKey = true;
        }
        else
        {
            ChangeColorFailer();
        }

        
        Debug.Log("ActiveKey");
    
       
    }




}
