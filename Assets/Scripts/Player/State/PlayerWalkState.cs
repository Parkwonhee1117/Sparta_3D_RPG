using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWalkState : PlayerGroundState
{
    private NavMeshAgent agent;
    private Transform target;

    public PlayerWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Initialize();

        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    void Initialize()
    {
        target = stateMachine.Player.Target;
        agent =  stateMachine.Player.Agent;

        agent.speed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        
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
            Debug.LogWarning("Null TargetLocation");
        }
    }

    public override void Update()
    {
        base.Update();
        
        if (target != null)
        {
            MoveToTarget(target.position);
        }
    }
}
