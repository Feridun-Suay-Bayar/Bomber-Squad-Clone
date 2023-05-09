using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Movements
{
    public class MissileMove : MonoBehaviour
    {
        GameObject player;
        Vector3 direction;
        private void OnEnable()
        {
            player = GameObject.FindWithTag("Player").transform.Find("Plane").gameObject;
            
            //direction = transform.position - player.transform.position;
            //direction.y += 1;
            //direction.z *=-1;
            //direction.x *=-1;
        }
        private void Start()
        {
            transform.LookAt(player.transform);
        }
        private void OnDisable()
        {
            player = null;
        }
        void Update()
        {
            transform.Translate(Vector3.forward * 6 * Time.deltaTime);
            if (transform.position.y >= 1.3f)
            {
                ObjectPooling.Instance.SetPoolObject(transform.gameObject, 3);
            }
        }
    }
}