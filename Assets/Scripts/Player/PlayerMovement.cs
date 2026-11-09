using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float minX = -4.5f;
    [SerializeField] private float maxX = 4.5f;

    private Rigidbody playerBody;
    private float horizontalInput;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = 0f;

        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
            return;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            horizontalInput -= 1f;

        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            horizontalInput += 1f;
    }

    private void FixedUpdate()
    {
        Vector3 nextPosition = playerBody.position;

        nextPosition.x += horizontalInput * moveSpeed * Time.fixedDeltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);

        playerBody.MovePosition(nextPosition);
    }
}