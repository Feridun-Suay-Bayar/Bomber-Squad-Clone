using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.UI
{
    public class HealthBarLook : MonoBehaviour
    {
        GameObject camera;
        // Start is called before the first frame update
        void Start()
        {
            camera = GameObject.FindWithTag("MainCamera");
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
        }
    }
}