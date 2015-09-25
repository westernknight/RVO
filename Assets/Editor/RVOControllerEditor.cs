#region 模块信息
/*----------------------------------------------------------------
// Copyright (C) 2015 广州，蓝弧
//
// 模块名：RVOControllerEditor
// 创建者：张嘉俊
// 修改者列表：
// 创建日期：#CREATIONDATE#
// 模块描述：
//----------------------------------------------------------------*/
#endregion


using UnityEngine;
using System.Collections;
using UnityEditor;
using Pathfinding.RVO;
[CustomEditor(typeof(RVOController))]
public class RVOControllerEditor : Editor {

	public   override void OnInspectorGUI()
{
 	 base.OnInspectorGUI();
     if (GUILayout.Button("pause"))
     {
         RVOController rvo = (RVOController)target;
         rvo.IsPause = !rvo.IsPause;
     }
}
}
