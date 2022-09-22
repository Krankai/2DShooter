using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class rotates the attached object (along the z-axis since it's 2D setting)
/// </summary>
public class AutoRotate : MonoBehaviour
{
    [Header("Setting")]
    [Tooltip("The direction in which the object is rotated")]
    public RotateDirection rotateDirection = RotateDirection.clockwise;

    [Tooltip("Rotating speed (in degree per second)")]
    public float speed = 15.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, (int)rotateDirection * speed * Time.deltaTime);
    }
}

public enum RotateDirection
{
    clockwise = 1,
    counterclockwise = -1,
}
