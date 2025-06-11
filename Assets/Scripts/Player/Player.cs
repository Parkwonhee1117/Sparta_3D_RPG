using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [Header("TargetLocation")]
    public Transform Target;


    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public UnityEngine.AI.NavMeshAgent Agent {get; private set;}

    public Animator Animator { get; private set; }
    private PlayerStateMachine stateMachine;

    void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        stateMachine = new PlayerStateMachine(this);
    }

    void Start()
    {
        stateMachine.ChangeState(stateMachine.WalkState);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
