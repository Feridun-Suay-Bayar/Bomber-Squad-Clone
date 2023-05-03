using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    Transform _transform;

    public PlaneRotation(Transform transform)
    {
        _transform = transform;
    }

    public void RotatePlane(Vector3 vector3,Transform mainTransform)
    {
        vector3.x = mainTransform.rotation.x;
        vector3.y = mainTransform.rotation.y;
        _transform.rotation = Quaternion.Lerp(mainTransform.rotation, Quaternion.Euler(vector3 * 45), 1f);
    }
}
