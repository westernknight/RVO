#region 模块信息
/*----------------------------------------------------------------
// Copyright (C) 2015 广州，蓝弧
//
// 模块名：DistanceDebugEditor
// 创建者：张嘉俊
// 修改者列表：
// 创建日期：9/9/2015
// 模块描述：
//----------------------------------------------------------------*/
#endregion


using UnityEngine;
using System.Collections;
using UnityEditor;
public class Vector2DebugEditor : EditorWindow
{


    float time;

    Vector2 firstObject;
    Vector2 secondObject;

    Vector2 lastFirstObject;
    Vector2 lastSecondObject;

    Vector2 verticalObject;
    float dis = 0;
    float dot = 0;
    float angle = 0;
    float det = 0;
    [MenuItem("Debug/Vector Test ")]
    static void Init()
    {
        Vector2DebugEditor window = (Vector2DebugEditor)EditorWindow.GetWindow(typeof(Vector2DebugEditor));
        window.Show();

    }
    void OnGUI()
    {



        EditorGUILayout.HelpBox("村长:", MessageType.Info);
        //EditorGUILayout.BeginHorizontal();
        firstObject = EditorGUILayout.Vector2Field("param1", firstObject);
        secondObject = EditorGUILayout.Vector2Field("param2", secondObject);

        if (lastFirstObject != firstObject || lastSecondObject != secondObject)
        {
            lastFirstObject = firstObject;
            lastSecondObject = secondObject;

            dis = Vector2.Distance(firstObject, secondObject);
            dot = Vector2.Dot(firstObject, secondObject);
            angle = Vector2.Angle(firstObject, secondObject);
            det = firstObject.x * secondObject.y - firstObject.y * secondObject.x;

            if (angle > 90)
            {
                if (det > 0)//param2 is unclockwise
                {

                    verticalObject = secondObject.Rotate(-(angle-90) );
                }
                else if (det == 0)
                {

                }
                else
                {
                    verticalObject = secondObject.Rotate( (angle-90));
                }
            }
            //verticalObject = secondObject.Rotate(45);

        }
        dis = EditorGUILayout.FloatField("Distance:", dis);
        dot = EditorGUILayout.FloatField("Dot:", dot);
        angle = EditorGUILayout.FloatField("Angle:", angle);
        det = EditorGUILayout.FloatField("Determinant:", det);
        verticalObject = EditorGUILayout.Vector2Field("Vertical", verticalObject);
        //EditorGUILayout.EndHorizontal();
    }
}