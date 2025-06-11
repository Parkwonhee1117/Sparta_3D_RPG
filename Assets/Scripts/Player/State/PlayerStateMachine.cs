using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    public Player Player {get;}

    public float MovementSpeed {get; private set;}
    public float RotationDamping {get; private set;}
    public float MovementSpeedModifier {get; set;} = 1f;

    public bool IsAttacking {get; set;}
    public int ComboIndex {get; set;}

    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }

    public PlayerStateMachine(Player player)
    {
        Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}
