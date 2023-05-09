using BomberSquad.Controller;
using BomberSquad.SO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BomberSquad.Health
{
    public class HealthControl : MonoBehaviour
    {
        [SerializeField] SOHealth _healthSO;
        public float currentHealth;
        public bool dead;
        [SerializeField] Image _image;
        [SerializeField] Image _image2;

        HealthImage _healthImage;
        HealthImage _healthImage2;
        PlayerController _player;

        [SerializeField] GameObject _particle1;
        [SerializeField] GameObject _particle2;

        public float MaxHealth => _healthSO.maxHealth;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = _healthSO.maxHealth;
            _healthImage = new HealthImage(_image);
            _healthImage2= new HealthImage(_image2);
            _player= GetComponent<PlayerController>();
            _particle1.SetActive(false);
            _particle2.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            _healthImage.SetImage(currentHealth,_healthSO.maxHealth);
            _healthImage2.SetImage(currentHealth, _healthSO.maxHealth);
            SetParticles();
            if (currentHealth <= 0)
            {
                _player.DeadTrigger();
                currentHealth = 0;
                dead = true;
            }
            if(currentHealth > 0)
            {
                dead = false;
            }
        }

        private void SetParticles()
        {
            if (currentHealth <= 60)
            {
                _particle1.SetActive(true);
            }
            else
            {
                _particle1.SetActive(false);
            }
            if (currentHealth <= 30)
            {
                _particle2.SetActive(true);
            }
            else
            {
                _particle2.SetActive(false);
            }
        }
    }
}