using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBehaviour : MonoBehaviour
{
    float time;

    private void Start()
    {
       
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 2f)
        {
            ObjectPooling.Instance.SetPoolObject(transform.gameObject, 2);
        }
    }
}
