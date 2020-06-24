using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTotarget : MonoBehaviour
{
    public GameObject Target;
    public Camera Cam;
    private void Update()
    {
        Vector3 pos = Cam.WorldToScreenPoint(Target.transform.position);
        transform.position = new Vector3(pos.x, pos.y, 0);
    }
}
