using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindownPopUP : Windown
{
    // Start is called before the first frame update
    public float time;
    public bool open = false;
    public override void Event_Open()
    {
        open = false;
        time = 0;
    }
    private void Update()
    {
        if (time > 2)
        {
            if (!open)
            {
               
                open = true;
                Active();
            }

        }
        else
        {
            time += Time.deltaTime;
        }
    }

    public virtual void Active()
    {
        GameManager.Ins.OpenWindown(TypeWindown.NextLevel);
    }
}
