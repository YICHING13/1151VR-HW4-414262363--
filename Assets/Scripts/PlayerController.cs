
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 25f;
    public float moveSpeed = 15f;

    public float horizontalLimit = 4f;
    public float minHeight = 4f;
    public float maxHeight = 14f;

    [Header("Mobile Controls")]
    public float touchSensitivity = 0.02f;

    private Vector2 lastTouchPosition;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 手機觸控：拖曳飛機
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.position - lastTouchPosition;

                horizontal = delta.x * touchSensitivity;
                vertical = delta.y * touchSensitivity;

                lastTouchPosition = touch.position;
            }
            else
            {
                horizontal = 0f;
                vertical = 0f;
            }
        }

        Vector3 movement = new Vector3(
            horizontal * moveSpeed,
            vertical * moveSpeed,
            forwardSpeed
        );

        transform.position += movement * Time.deltaTime;

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -horizontalLimit, horizontalLimit);
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);

        transform.position = pos;
    }
}
