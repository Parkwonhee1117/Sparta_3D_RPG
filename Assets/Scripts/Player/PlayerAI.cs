using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour
{
    [Header("Stats")]
    public float walkSpeed;

    [Header("TargetLocation")]
    public Transform target;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        MoveToTarget(target.position);
    }

    public void MoveToTarget(Vector3 targetPosition)
    {
        if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        else
        {
            Debug.LogWarning("유효한 NavMesh 위치를 찾지 못했습니다: " + targetPosition);
        }
    }
    void Update()
    {
        if(target != null)
        {
            MoveToTarget(target.position);
        }
    }
}

