using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    GameObject plane;
    private void Start()
    {
        plane = GameObject.Find("Player").transform.Find("Plane").gameObject;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * 200 * Time.deltaTime);
        transform.DOMove(plane.transform.position, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjectPooling.Instance.SetPoolObject(transform.gameObject,4);
        }
    }
}
