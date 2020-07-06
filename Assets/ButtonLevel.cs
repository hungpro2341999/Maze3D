using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    public int levelSelect;
    public Text Level;

    public void Play()
    {
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
        GamePlayCtrl.Ins.OpenLevel(levelSelect);
    }
}
