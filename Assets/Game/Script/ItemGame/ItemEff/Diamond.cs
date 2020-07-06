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
    public Color colorCurr;
    public Color colorActive;
    private void Awake()
    {
        colorCurr = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
    }
  

    public void ChangeColor()
    {
        Img.color = colorActive;
    }

    public override void ResetItem()
    {
        Img.color = colorCurr;
        ActiveKey = false;
    }

    private void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += speed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
   



    public void AciveDiamond()
    {
        var LocKGem = GamePlayCtrl.Ins.GetCurrLevel().GetLocKGemCurr();
        LocKGem.AddDiamond(this);
        
    }

    public void BackToNormarl()
    {
        Img.color = colorCurr;
    }

    public void ActiveDiamond()
    {
        ActiveKey = true;

    }
    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball1")
        {
            AciveDiamond();
        }
    }

}
