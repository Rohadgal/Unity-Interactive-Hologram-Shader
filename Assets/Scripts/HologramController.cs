using UnityEngine;

public class HologramController : MonoBehaviour
{
    [SerializeField]
    Material hologramMaterial;
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    private float intensity = 5f;

    void Update()
    {
        // float pulse =
        //     Mathf.Abs(
        //         Mathf.Sin(Time.time * speed)
        //     );

        hologramMaterial.SetFloat(
            "_Intensity",
            intensity
        );
        hologramMaterial.SetFloat(
            "_Speed",
            speed
        );
    }
}
