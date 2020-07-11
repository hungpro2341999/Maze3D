using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataImg",menuName ="ListImg")]
public class DataImg : ScriptableObject
{
    public List<Img_Level> Levels;
}

[System.Serializable]
public class Img_Level
{
    public int level;
    public Sprite Img;

}      
