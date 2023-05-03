using BomberSquad.Movements;
using System.Collections;
using System.Collections.Generic;
using BomberSquad.Inputs;
using UnityEngine;

namespace BomberSquad.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] float _rotationSpeed;
        [SerializeField] Transform _planeTransform;

        Rigidbody _rigidbody;
        JoystickInput _joystickInput;
        PlayerMovement _movement;
        PlaneRotation _planeRotation;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _joystickInput = GetComponent<JoystickInput>();
            _movement = new PlayerMovement(transform, _speed,_rigidbody,_rotationSpeed);
            _planeRotation = new PlaneRotation(_planeTransform);
        }
        private void Update()
        {
            _movement.Move(_joystickInput.MovementVector);
            _planeRotation.RotatePlane(_joystickInput.RotationVector,transform);
        }
    }
}