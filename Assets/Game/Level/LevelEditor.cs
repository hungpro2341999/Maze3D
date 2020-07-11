//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//[CustomEditor(typeof(Level))]
//public class LevelEditor : Editor
//{
//    public Level Target;
//    public override void OnInspectorGUI()
//    {
//        Target = (Level)target;

//        GUILayout.BeginHorizontal();


//        GUILayout.EndHorizontal();
//        GUILayout.BeginHorizontal();



//        GUILayout.EndHorizontal();

//        GUILayout.Space(20);

//        GUILayout.BeginHorizontal();

//        if (GUILayout.Button("Load"))
//        {
//            Target.SetUp();
//            EditorUtility.SetDirty(Target);
//        }


//        GUILayout.EndHorizontal();

//    }
//}
