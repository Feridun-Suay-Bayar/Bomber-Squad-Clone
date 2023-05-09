using BomberSquad.Managers;
using BomberSquad.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BomberSquad.Health
{
    public class TankHealthControl : MonoBehaviour
    {
        [SerializeField] SOHealth _healthSO;
        public float currentHealth;
        [SerializeField] Image _image;

        HealthImage _healthImage;
        float _time;
        bool _isDead;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = _healthSO.maxHealth;
            _healthImage = new HealthImage(_image);
        }

        // Update is called once per frame
        void Update()
        {
            _healthImage.SetImage(currentHealth,_healthSO.maxHealth,Color.red);
            if (currentHealth <= 0)
            {
                _isDead = true;
                
            }
            if (_isDead)
            {
                _time += Time.deltaTime;
                if (_time >= 1f)
                {
                    transform.gameObject.SetActive(false);
                    var obj = ObjectPooling.Instance.GetPoolObject(4);
                    LevelManager.Instance.AddLevelValue(1);
                    obj.transform.position = transform.position + new Vector3(0,1,0);
                }
            }
        }
    }
}