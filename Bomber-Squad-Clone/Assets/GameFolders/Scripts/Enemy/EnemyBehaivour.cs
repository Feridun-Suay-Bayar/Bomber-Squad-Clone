using BomberSquad.Animation;
using BomberSquad.Combat;
using BomberSquad.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Behaivours
{
    public class EnemyBehaivour : MonoBehaviour
    {
        Quaternion startRotation;
        GameObject player;
        AnimationController _animController;
        EnemyCombatControl _enemyCombatControl;

        bool _isDead = false;
        float _time;
        private void Start()
        {
            startRotation = transform.rotation;
            _animController = GetComponent<AnimationController>();
            _enemyCombatControl= GetComponent<EnemyCombatControl>();
        }
        private void Update()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            else
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= 1.15f && !_isDead) // Menzil önemli
                {
                    transform.LookAt(player.transform);
                    transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                    _animController.ShootAnimation();
                    _enemyCombatControl.StartFire();
                }
                else
                {
                    transform.rotation = startRotation;
                    _animController.IdleAnimation();
                    player = null;
                }
            }
            if (_isDead)
            {                
                _time += Time.deltaTime;
                if (_time >= 2f)
                {
                    transform.gameObject.SetActive(false);
                    var obj = ObjectPooling.Instance.GetPoolObject(4);
                    obj.transform.position = transform.position;
                    obj.transform.position = transform.position + new Vector3(0, 0.05f, 0);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Explosive") && !_isDead)
            {
                _isDead = true;
                _animController.DeadAnimation();
                LevelManager.Instance.AddLevelValue(1);
            }
        }
    }
}