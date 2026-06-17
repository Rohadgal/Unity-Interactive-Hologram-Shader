using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float height = 2f;
    [SerializeField] private float sensitivity = 1f;

    private float yaw;
    private float pitch = 20f;

    private void LateUpdate()
    {
        if (Mouse.current != null)
        {
            Vector2 mouseDelta =
                Mouse.current.delta.ReadValue();

            yaw += mouseDelta.x * sensitivity;
            pitch -= mouseDelta.y * sensitivity;

            pitch = Mathf.Clamp(
                pitch,
                -30f,
                80f);
        }

        Quaternion rotation =
            Quaternion.Euler(
                pitch,
                yaw,
                0f);

        Vector3 offset =
            rotation *
            new Vector3(
                0,
                0,
                -distance);

        transform.position =
            target.position +
            Vector3.up * height +
            offset;

        transform.LookAt(
            target.position +
            Vector3.up * height);
    }
}
