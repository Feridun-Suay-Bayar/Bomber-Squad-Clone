using BomberSquad.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Behaivours
{
    public class EnemyBaseBehaviour : MonoBehaviour
    {
        bool _isDead;
        public bool IsDead => _isDead;

        public void SetDamageParticles(float currentHealth, float maxHealth,
            GameObject p1, GameObject p2, GameObject p3, GameObject p4)
        {
            float damageDegre = (currentHealth / maxHealth) * 100;
            if (damageDegre >= 70 && damageDegre <=85)
            {
                p1.gameObject.SetActive(true);
            }
            else if (damageDegre >= 50 && damageDegre < 70)
            {
                p2.gameObject.SetActive(true);
            }
            else if (damageDegre >= 25 && damageDegre < 50)
            {
                p3.gameObject.SetActive(true);
            }
            else if (damageDegre <= 0)
            {
                _isDead = true;
                p4.gameObject.SetActive(true);
            }
        }
    }
}