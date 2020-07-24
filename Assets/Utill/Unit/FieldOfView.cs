using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask[] targetMask;
    public LayerMask[] obstacleMask;
    public bool test =true;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
      //  StartCoroutine("FindTargetsWithDelay", .2f);
      //  StartCoroutine(FindTargetsWithDelay(.2f));
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
          // FindVisibleTargets();
        }
    }

    public Collider2D GetTarget(Act callback=null)
    {
        Collider2D targetsInViewRadius = Physics2D.OverlapCircle(transform.position, viewRadius, LayerMaskUtill.Composit(targetMask));
        if (callback != null)
        {
            callback(targetsInViewRadius);
        }
  

        return targetsInViewRadius;
    }

    /// <summary>
    /// 각도를 무시하고 전체 타겟을 불러옵니다.
    /// </summary>
    /// <returns></returns>
    public Collider2D[] GetAllTargets()
    {
       

        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, LayerMaskUtill.Composit(targetMask));



        return targetsInViewRadius;
    }


    public List<Transform> GetTargetsTransform(Act act=null)
    {
        visibleTargets.Clear();
        Debug.Log("targetMask" + targetMask);
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, LayerMaskUtill.Composit(targetMask));
       Debug.Log("루틴 테스트"+ targetsInViewRadius.Length);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;// 방향
            if (Vector3.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, LayerMaskUtill.Composit(obstacleMask)))
                {
                   
                        visibleTargets.Add(target);
                        act(targetsInViewRadius[i]);
                    

                }
            }
        }
        return visibleTargets;
    }

    public List<Collider2D> GetTargetsCollider2D(Act act=null)
    {
        visibleTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, LayerMaskUtill.Composit(targetMask));
        List<Collider2D> targetCollider = new List<Collider2D>();
        Debug.Log("루틴 테스트" + targetsInViewRadius.Length);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;// 방향 설정
            if (Vector3.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, LayerMaskUtill.Composit(obstacleMask)))
                {
                    targetCollider.Add(targetsInViewRadius[i]);
                    act(targetsInViewRadius[i]);
                }
            }
        }

        return targetCollider;
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


    public static FieldOfView GetComponent(GameObject gameObject)
    {
        FieldOfView fieldOfView= gameObject.GetComponent<FieldOfView>();

        if (gameObject.GetComponent<FieldOfView>() == null)
        {
            fieldOfView = gameObject.AddComponent<FieldOfView>();
        }
       
        return fieldOfView;
    }


    public delegate void Act(Collider2D target);


}