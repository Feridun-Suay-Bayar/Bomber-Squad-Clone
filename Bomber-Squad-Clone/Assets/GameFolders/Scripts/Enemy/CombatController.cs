using BomberSquad.Controller;
using BomberSquad.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

namespace BomberSquad.Combat
{
    public class CombatController : MonoBehaviour
    {
        [SerializeField] Transform _transform;

        PlayerController _playerController;
        PlayerStats _playerStats;
        float maxDelay = 0.5f;
        float currentTime;
        int _ammo;
        // Start is called before the first frame update
        void Start()
        {
            _playerController= GetComponent<PlayerController>();
            _playerStats = GetComponent<PlayerStats>();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (!_playerController.CanShoot) return;

            currentTime += Time.deltaTime;
            if (currentTime >= maxDelay) 
            {
                Shoot();
                currentTime = 0;
            }
        }
        void Shoot()
        {
            if ( _playerStats.ammo > 0)
            {
                var obj = ObjectPooling.Instance.GetPoolObject(1);
                obj.transform.position = _transform.position;
                _playerStats.ammo--;
            }
        }
    }
}