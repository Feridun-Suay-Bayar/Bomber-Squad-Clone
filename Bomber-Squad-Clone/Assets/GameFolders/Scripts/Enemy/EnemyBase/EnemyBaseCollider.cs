using BomberSquad.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Colliders
{
    public class EnemyBaseCollider : MonoBehaviour
    {
        PlayerStats _playerStats;
        EnemyBaseStats _enemyStats;
        void Start()
        {
            _playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
            _enemyStats = GetComponent<EnemyBaseStats>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bomb"))
            {
                _enemyStats.currentHealth -= _playerStats.Damage;
            }
        }
    }
}