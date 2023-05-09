using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Combat
{
    public class EnemyCombatControl : MonoBehaviour
    {
        [SerializeField] Transform _gunPoint;
        float maxDelay = 0.5f;
        float currentTime;
        [SerializeField] int bulletType;
        private void Start()
        {
            
        }
        public void StartFire()
        {
            currentTime += Time.deltaTime;
            if (currentTime >= maxDelay)
            {
                var obj = ObjectPooling.Instance.GetPoolObject(bulletType);
                obj.transform.position = _gunPoint.position;
                currentTime = 0;
            } 
        }
        public void StartFireTank()
        {
            currentTime += Time.deltaTime;
            if (currentTime >= maxDelay+1)
            {
                var obj = ObjectPooling.Instance.GetPoolObject(bulletType);
                obj.transform.position = _gunPoint.position;
                currentTime = 0;
            }
        }
    }
}