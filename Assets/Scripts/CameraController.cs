using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 velocity;
    public Vector3 Velocity => velocity;

    public GameObject player;

    private Vector3 lastPosition;
    private Vector3 currentVelocity;

    [SerializeField] 
    private float cameraMoveSpeed = 4.0f; // ī�޶� �̵� �ӵ�


    private void Start()
    {
        Application.targetFrameRate = 60; // ���ϴ� FPS
        QualitySettings.vSyncCount = 0;   // V-Sync ����
    }

    private void Update()
    {
        velocity = (transform.position - lastPosition) / Time.deltaTime; 
        lastPosition = transform.position;
    }

    void FixedUpdate()  
    {
        if (player != null)
        {
            Vector3 targetPosition = player.transform.position;
            targetPosition.y = transform.position.y;
            targetPosition.z = transform.position.z;

            // �ȼ� ����Ʈ ���� (X, Y �� ��)
            {
                float pixelSize = 1f / 16.0f;
                targetPosition.x = Mathf.Round(targetPosition.x / pixelSize) * pixelSize;
                targetPosition.y = Mathf.Round(targetPosition.y / pixelSize) * pixelSize;
            }

            // SmoothDamp�� �ε巴�� �̵�
            Vector3 smoothPosition = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref currentVelocity,
                smoothTime : 0.1f // �ε巴�� �̵��ϴ� �ð�
            );

            transform.position = smoothPosition;
        }
    }
}
