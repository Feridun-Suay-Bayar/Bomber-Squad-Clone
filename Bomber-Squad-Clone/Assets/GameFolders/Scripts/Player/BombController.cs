using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Land"))
        {
            var obj = ObjectPooling.Instance.GetPoolObject(2);
            obj.transform.position = transform.position;
            ObjectPooling.Instance.SetPoolObject(transform.gameObject, 1);
        }
    }
}
