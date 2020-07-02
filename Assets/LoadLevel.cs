//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//[CustomEditor(typeof(LoadAllLevel))]
//public class LoadLevel : Editor
//{
//    public LoadAllLevel Target;
//    public override void OnInspectorGUI()
//    {
//        Target = (LoadAllLevel)target;

//        GUILayout.BeginHorizontal();


//        GUILayout.EndHorizontal();
//        GUILayout.BeginHorizontal();



//        GUILayout.EndHorizontal();

//        GUILayout.Space(20);

//        GUILayout.BeginHorizontal();

//        if (GUILayout.Button("Load"))
//        {


//            Target.LoadStart();
//            EditorUtility.SetDirty(Target);
//        }


//        GUILayout.EndHorizontal();

//    }
//}
