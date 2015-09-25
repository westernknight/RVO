#region 模块信息
/*----------------------------------------------------------------
// Copyright (C) 2015 广州，蓝弧
//
// 模块名：MonsterAutoBehavior
// 创建者：张嘉俊
// 修改者列表：
// 创建日期：#CREATIONDATE#
// 模块描述：
//----------------------------------------------------------------*/
#endregion


using UnityEngine;
using System.Collections;
using Pathfinding.RVO;

public class MonsterAutoBehavior : MonoBehaviour {

    RVOController rvo;
    public float speed = 1;
    public bool stop = false;
	void Start()
	{
        rvo = GetComponent<RVOController>();
        rvo.Move(Vector3.right * speed);
        rvo.maxSpeed = speed;
	}
    void Update()
    {
        if (stop)
        {
            rvo.Move(Vector3.zero);
        }
    }
}
