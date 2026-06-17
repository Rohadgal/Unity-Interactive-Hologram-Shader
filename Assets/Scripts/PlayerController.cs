using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Look")]
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform cameraPivot;

    private CharacterController controller;

    private float pitch = 0f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed)
                input.y += 1;

            if (Keyboard.current.sKey.isPressed)
                input.y -= 1;

            if (Keyboard.current.dKey.isPressed)
                input.x += 1;

            if (Keyboard.current.aKey.isPressed)
                input.x -= 1;
        }

        Vector3 moveDirection =
            transform.right * input.x +
            transform.forward * input.y;

        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {
        if (Mouse.current == null)
            return;

        Vector2 mouseDelta =
            Mouse.current.delta.ReadValue();

        float mouseX =
            mouseDelta.x *
            mouseSensitivity *
            Time.deltaTime;

        float mouseY =
            mouseDelta.y *
            mouseSensitivity *
            Time.deltaTime;

        // Left / Right
        transform.Rotate(Vector3.up * mouseX);

        // Up / Down
        pitch -= mouseY;

        pitch = Mathf.Clamp(
            pitch,
            -80f,
            80f);

        cameraPivot.localRotation =
            Quaternion.Euler(
                pitch,
                0f,
                0f);
    }
}