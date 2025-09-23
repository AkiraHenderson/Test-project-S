using UnityEngine;


[System.Serializable]
public class MovementHandler
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public float wallSlideSpeed = 2f;
    public float wallJumpForce = 12f;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Transform transform;
    private LayerMask obstacleLayer;

    public void Initialize(Rigidbody2D rb, BoxCollider2D collider, Transform tr, LayerMask layer)
    {
        rigidBody = rb;
        boxCollider = collider;
        transform = tr;
        obstacleLayer = layer;
    }

    public void Move(float moveInput)
    {
        if (moveInput != 0)
            transform.localScale = new Vector3(moveInput, 1, 1);

        Vector2 velocity = rigidBody.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rigidBody.linearVelocity = velocity;
    }

    public void Jump()
    {
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
    }

    public bool IsGrounded()
    {
        float extraHeight = 0.1f;
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * 0.7f, 0.05f);
        Vector2 origin = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.min.y - 0.01f);

        RaycastHit2D hit = Physics2D.BoxCast(origin, boxSize, 0f, Vector2.down, extraHeight, obstacleLayer);
        return hit.collider != null;
    }

    public bool IsTouchingWall()
    {
        Bounds bounds = boxCollider.bounds;
        Vector2 origin = bounds.center;
        Vector2 size = new Vector2(bounds.size.x, bounds.size.y * 0.8f);
        int direction = IsFacingRight() ? 1 : -1;

        return Physics2D.BoxCast(origin, size, 0f, Vector2.right * direction, 0.1f, obstacleLayer);
    }

    public bool IsFacingRight() => transform.localScale.x > 0;
}
