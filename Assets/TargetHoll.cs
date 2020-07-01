using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHoll : FallHool
{

    public override void EndTrap()
    {
        GameManager.Ins.OpenWindown(TypeWindown.NextLevel);
    }
    public override void SetTarget()
    {
        if (GetComponent<Renderer>() != null)
        {
            Target = GetComponent<Renderer>().bounds.center;
        }
        else
        {
            Target = transform.position;
        }
    }
}
