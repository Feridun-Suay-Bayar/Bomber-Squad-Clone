using BomberSquad.Behaivours;
using BomberSquad.Health;
using BomberSquad.Managers;
using BomberSquad.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BomberSquad.Stats
{
    public class EnemyBaseStats : MonoBehaviour
    {
        [SerializeField] SOHealth _healthSO;
        [SerializeField] Image _image;
        
        public SOHealth SOHealth => _healthSO;

        HealthImage _healthImage;
        EnemyBaseBehaviour _enemyBaseBehaviour;

        [HideInInspector]
        public float currentHealth;
        float _time;

        [SerializeField] GameObject _particle1;
        [SerializeField] GameObject _particle2;
        [SerializeField] GameObject _particle3;
        [SerializeField] GameObject _particle4;

        void Start()
        {
            currentHealth = _healthSO.maxHealth;
            _healthImage = new HealthImage(_image);
            _enemyBaseBehaviour= new EnemyBaseBehaviour();
            _particle4.SetActive(false);
            _particle3.SetActive(false);
            _particle2.SetActive(false);
            _particle1.SetActive(false);
        }

        void Update()
        {
            _healthImage.SetImage(currentHealth, _healthSO.maxHealth, Color.red);
            _enemyBaseBehaviour.SetDamageParticles(currentHealth,_healthSO.maxHealth,
                _particle1,_particle2,_particle3,_particle4);

            if (_enemyBaseBehaviour.IsDead)
            {
                _time += Time.deltaTime;
                if (_time >= 2f)
                {
                    transform.gameObject.SetActive(false);
                    LevelManager.Instance.AddLevelValue();
                }
            }
        }
        
    }
}