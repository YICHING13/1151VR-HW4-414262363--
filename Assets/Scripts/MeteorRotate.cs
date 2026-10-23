
using UnityEngine;

public class MeteorRotate : MonoBehaviour
{
    public float rotationSpeed = 40f;

    void Update()
    {
        transform.Rotate(
            15f * Time.deltaTime,
            rotationSpeed * Time.deltaTime,
            10f * Time.deltaTime
        );
    }
}
