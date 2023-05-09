using BomberSquad.Movements;
using System.Collections;
using System.Collections.Generic;
using BomberSquad.Inputs;
using UnityEngine;
using BomberSquad.Managers;
using BomberSquad.Health;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace BomberSquad.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] float _rotationSpeed;
        [SerializeField] Transform _planeTransform;
        [SerializeField] GameObject landArea;

        Rigidbody _rigidbody;
        JoystickInput _joystickInput;
        PlayerMovement _movement;
        CrossHairControl _crosshairControl;
        HealthControl _healthControl;
        public Transform PlaneTransform => transform;
        public bool CanShoot => _crosshairControl.CanShoot;
        Animator anim;

        float time = 0;
        float time2 = 0;

        bool onLand;
        bool onAir;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _joystickInput = GetComponent<JoystickInput>();
            _movement = new PlayerMovement(transform, _speed,_rigidbody,_rotationSpeed);
            _healthControl = GetComponent<HealthControl>();
            _crosshairControl = transform.Find("Canvas").transform.Find("CrossHair").GetComponent<CrossHairControl>();
            anim = transform.Find("Plane").GetComponent<Animator>();
        }
        private void Update()
        {
            if (_crosshairControl.CanHeal)
            {
                time2 += Time.deltaTime;
                if (time2 > 0.5f)
                {
                    if (_healthControl.currentHealth < _healthControl.MaxHealth)
                    {
                        _healthControl.currentHealth += 10;
                    }
                    else
                    {
                        _healthControl.currentHealth = _healthControl.MaxHealth;
                    }
                    time2 = 0;
                }
            }

            if (!GameManager.Instance.isGameStart)
            {
                anim.ResetTrigger("dead");
                return;
            }
            _movement.Move(_joystickInput.MovementVector);
            
            if (onLand)
            {
                time+= Time.deltaTime;
                if (time >= 1f)
                {
                    GameManager.Instance.isGameStart = false;
                    landArea.transform.position = new Vector3(landArea.transform.position.x, 1f, landArea.transform.position.z);
                    transform.position = landArea.transform.position;
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                    onLand= false;
                    time = 0;
                }
            }
        }
        public void StartTrigger()
        {
            anim.SetTrigger("start");
        }
        public void DeadTrigger()
        {
            anim.SetTrigger("dead");
            time += Time.deltaTime;
            _healthControl.dead = true;
            if (time >= 1.5f)
            {
                onLand = true;
                onAir = false;
                time = 0f;
            }
        }
        public void LandTrigger()
        {
            anim.SetTrigger("land");
            onLand = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("landarea") && onAir)
            {
                LandTrigger();
                onAir = false;
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("landarea") && onAir)
            {
                onAir = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("landarea"))
            {
                onAir = true;
            }
        }
    }
}