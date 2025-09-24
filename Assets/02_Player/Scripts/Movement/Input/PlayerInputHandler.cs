using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerInputHandler : MonoBehaviour
{

    private float moveInput;
    public float MoveInput => moveInput;
    MovementHandler movementHandler;

    // �ֱ� �Է� ���

    private float leftPressTime = -1f;
    private float rightPressTime = -1f;
    private bool leftHeld, rightHeld;

    public void Initialize(MovementHandler movementHandler)
    {
        this.movementHandler = movementHandler;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            // Ű ���� ������Ʈ
            leftHeld = Keyboard.current.aKey.isPressed;
            rightHeld = Keyboard.current.dKey.isPressed;

            // ���� ���� ���
            if (context.performed)
            {
                if (context.control == Keyboard.current.aKey)
                    leftPressTime = Time.time;
                else if (context.control == Keyboard.current.dKey)
                    rightPressTime = Time.time;
            }

            // ���� ����
            if (leftHeld && rightHeld)
                moveInput = (leftPressTime > rightPressTime) ? -1f : 1f;
            else if (leftHeld)
                moveInput = -1f;
            else if (rightHeld)
                moveInput = 1f;
            else
                moveInput = 0f;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movementHandler.Jump();
        }
    }
}
