using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Diamond : Item
{
    public SpriteRenderer Img;
    
    public float speed;
    public bool ActiveKey = false;
    public void ChangeColor()
    {
        Img.color = new Color(0.5f, 0.5f, 0.5f, 1);
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
        ChangeColor();
        Debug.Log("ActiveKey");
        LockGem.CountUnGem += 1;
        ActiveKey = true;
    }




}
