using BomberSquad.Health;
using BomberSquad.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Colliders
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] int _bulletDamage;
        [SerializeField] int _missileDamage;
        
        HealthControl _healtControl;
        PlayerStats _playerStats;
        
        private void Start()
        {
            _healtControl = GetComponent<HealthControl>();
            _playerStats= GetComponent<PlayerStats>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                int damage = _bulletDamage - ((_bulletDamage * _playerStats.Armor )/ 100);
                _healtControl.currentHealth -= damage;
                ObjectPooling.Instance.SetPoolObject(other.gameObject, 0);
            }
            if (other.CompareTag("Missile"))
            {
                int damage = _missileDamage - ((_missileDamage * _playerStats.Armor) / 100);
                _healtControl.currentHealth -= damage;
                ObjectPooling.Instance.SetPoolObject(other.gameObject, 0);
            }
            if (other.CompareTag("Coin"))
            {
                _playerStats.AddCoin();
            }
        }
    }
}