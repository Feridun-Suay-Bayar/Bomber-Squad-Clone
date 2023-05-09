using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Movements
{
    public class BulletMove : MonoBehaviour
    {
        GameObject player;
        // Start is called before the first frame update
        private void OnEnable()
        {
            player = GameObject.FindWithTag("Player").transform.Find("Plane").gameObject;
            
        }
        private void Start()
        {
            transform.LookAt(player.transform);
        }
        private void OnDisable()
        {
            player = null;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * 6 * Time.deltaTime);
            if (transform.position.y >= 1.3f)
            {
                ObjectPooling.Instance.SetPoolObject(transform.gameObject, 0);
            }
        }
    }
}