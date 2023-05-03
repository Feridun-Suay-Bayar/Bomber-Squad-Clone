using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairControl : MonoBehaviour
{
    [SerializeField] Image _image;
    Color colorBlack;
    Color colorRed;

    private void Start()
    {
        colorBlack = Color.black;
        colorRed = Color.red;
        _image.color = colorBlack;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _image.color = colorRed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _image.color = colorBlack;
        }
    }
}
