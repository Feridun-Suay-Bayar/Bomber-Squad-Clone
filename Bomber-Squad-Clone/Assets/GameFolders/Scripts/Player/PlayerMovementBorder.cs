using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Movements
{
    public class PlayerMovementBorder : MonoBehaviour
    {
        [SerializeField] GameObject wall_1;
        [SerializeField] GameObject wall_2;
        [SerializeField] GameObject wall_3;
        [SerializeField] GameObject wall_4;

        void FixedUpdate()
        {
            float x = Mathf.Clamp(transform.position.x, wall_1.transform.position.x, wall_2.transform.position.x);
            float y = transform.position.y;
            float z = Mathf.Clamp(transform.position.z, wall_3.transform.position.z, wall_4.transform.position.z);

            transform.position = new Vector3(x, y, z);
        }
    }
}