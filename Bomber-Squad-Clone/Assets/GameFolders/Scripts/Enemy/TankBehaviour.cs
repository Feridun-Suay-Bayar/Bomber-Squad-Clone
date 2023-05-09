using BomberSquad.Combat;
using BomberSquad.Health;
using BomberSquad.Managers;
using BomberSquad.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Behaivours
{
    public class TankBehaviour : MonoBehaviour
    {
        Quaternion startRotation;
        GameObject player;
        EnemyCombatControl _enemyCombatControl;
        PlayerStats _playerStats;
        TankHealthControl _tankHealth;
        void Start()
        {
            startRotation = transform.rotation;
            _enemyCombatControl = GetComponent<EnemyCombatControl>();
            _playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
            _tankHealth = GetComponent<TankHealthControl>();
        }

        // Update is called once per frame
        void Update()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            else
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= 1.15f) // Menzil önemli
                {
                    transform.LookAt(player.transform);
                    transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                    _enemyCombatControl.StartFireTank();
                }
                else
                {
                    player = null;
                }
            }
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Explosive"))
            {
                _tankHealth.currentHealth -= _playerStats.Damage;
                
            }
        }
    }
}