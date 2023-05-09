using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairControl : MonoBehaviour
{
    GameObject enemy;
    [SerializeField] Image _image;
    Color colorBlack;
    Color colorRed;
    bool canShoot;
    bool canHeal;
    public bool CanShoot => canShoot;
    public bool CanHeal => canHeal; 
    
    private void Start()
    {
        colorBlack = Color.black;
        colorRed = Color.red;
        _image.color = colorBlack;
    }
    private void Update()
    {
        if (enemy != null)
        {
            if (!enemy.active)
            {
                _image.color = colorBlack;
                enemy = null;
                canShoot = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBase"))
        {
            _image.color = colorRed;
            enemy = other.gameObject;
            canShoot = true;
        }
        if (other.CompareTag("Road"))
        {
            canHeal= true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBase"))
        {
            _image.color = colorRed;
            enemy = other.gameObject;
            canShoot = true;
        }
        if (other.CompareTag("Road"))
        {
            canHeal = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBase"))
        {
            _image.color = colorBlack;
            canShoot = false;
        }
        if (other.CompareTag("Road"))
        {
            canHeal = false;
        }
    }
    
}
