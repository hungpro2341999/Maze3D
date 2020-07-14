using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataImg",menuName ="ListImg")]
public class DataImg : ScriptableObject
{
    public List<Img_Level> Levels;

    public Sprite GetLevel(int level)
    {
        foreach(var img in Levels)
        {
            if(level == img.level)
            {
                return img.Img;
            }
        }
        return null;
    }
}

[System.Serializable]
public class Img_Level
{
    public int level;
    public Sprite Img;


    
}      
