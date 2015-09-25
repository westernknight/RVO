#region 模块信息
/*----------------------------------------------------------------
// Copyright (C) 2015 广州，蓝弧
//
// 模块名：EnemyHumanControlBehavior
// 创建者：张嘉俊
// 修改者列表：
// 创建日期：#CREATIONDATE#
// 模块描述：
//----------------------------------------------------------------*/
#endregion


using UnityEngine;
using System.Collections;
using Pathfinding.RVO;

public class EnemyHumanControlBehavior : MonoBehaviour {

    Vector3 desireDirectory;
    Camera gameCamera;
    RaycastHit hit;
    RVOController rvo;
    public float moveSpd = 5;
    Vector3 targetPoint = Vector3.zero;
    public bool isStartBreak = false;
    public bool arriveBreak = false;
    enum EStatus
    {
        stop,
        prerun,
        running,
    }
    EStatus status = EStatus.stop;
    float lastDistance;
    float nowDistance;
    void Start()
    {
        gameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        rvo = GetComponent<RVOController>();
    }
    bool DoRayCast()
    {

        if (Physics.Raycast(
            gameCamera.ScreenPointToRay(Input.mousePosition),
            out hit))
        {
            return true;
        }
        return false;// ActionHelpers.IsMouseOver(testObject, rayDistance.Value, ActionHelpers.LayerArrayToLayerMask(layerMask, invertMask.Value));
    }
    void OnDrawGizmos()
    {
        if (targetPoint!=Vector3.zero)
        {
            Gizmos.DrawWireSphere(targetPoint, 0.5f);
        }
    }
    void Update()
    {
        //        Debug.Log("be update");
        if (Input.GetMouseButtonDown(0))
        {
            if (DoRayCast())
            {
                desireDirectory = hit.point - transform.position;
                targetPoint = hit.point;
                rvo.Move(desireDirectory.normalized * moveSpd);
                //Debug.Log(dir.normalized * moveSpd);
                rvo.maxSpeed = moveSpd;
                status = EStatus.running;
                nowDistance = lastDistance = Vector3.Distance(transform.position, hit.point);
                //Debug.LogWarning("nowDistance = lastDistance " + nowDistance + " " + transform.position);
                if (isStartBreak)
                {
                    Debug.Break();
                }
                
            }
        }
        if (status == EStatus.running)
        {
            Vector3 movevec = hit.point - transform.position;
            Vector2 firstObject = new Vector2(desireDirectory.x, desireDirectory.z);
            Vector2 secondObject = new Vector2(movevec.x, movevec.z);
            float det = firstObject.x * secondObject.y - firstObject.y * secondObject.x;
            if (Vector3.Dot(movevec, desireDirectory)<0)
            {
                if (arriveBreak)
                {
                    Debug.Break();
                }
       
                rvo.Move(Vector3.zero);
                status = EStatus.stop;
            }
            
        }

    }
}
