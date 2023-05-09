using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Animation
{
    public class AnimationController : MonoBehaviour
    {
        Animator anim;
        void Start()
        {
            anim = transform.GetComponentInChildren<Animator>();
        }
        public void ShootAnimation()
        {
            anim.SetTrigger("Shoot");
        }
        public void IdleAnimation()
        {
            anim.SetTrigger("Idle");
        }
        public void DeadAnimation()
        {
            anim.SetTrigger("Death");
        }
    }
}