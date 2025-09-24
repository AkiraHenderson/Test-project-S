using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerMovementController : MonoBehaviour
{
    public PlayerStateMachine stateMachine;

    [Header("References")]
    public Rigidbody2D rigidBody;

    [HideInInspector] public Animator animator;

    [Header("References")]
    public BoxCollider2D boxCollider;   // Player의 Collider
    public LayerMask obstacleLayer;



    public MovementHandler movementHandler = new MovementHandler();
    [HideInInspector] public PlayerInputHandler inputHandler;
    [HideInInspector] public AnimationController animationController;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        animator = GetComponent<Animator>();
        movementHandler.Initialize(rigidBody, boxCollider, transform, obstacleLayer);

        animationController = GetComponent<AnimationController>();
        inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.Initialize(movementHandler);
    }
    void Start()
    {
        stateMachine = new PlayerStateMachine(this);
        stateMachine.Initialize(stateMachine.idleState); // Idle 상태로 시작


    }
    // Update is called once per frame
    void Update()
    {
        //HandleMoveInput();

        if (stateMachine != null)
        {
            //moveInput = Input.GetAxisRaw("Horizontal");
            stateMachine.Update();
        }
    }
    private void FixedUpdate()
    {
        movementHandler.Move(inputHandler.MoveInput);
    }   
}
