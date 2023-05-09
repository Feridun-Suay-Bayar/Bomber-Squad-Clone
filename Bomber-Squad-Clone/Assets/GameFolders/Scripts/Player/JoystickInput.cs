using BomberSquad.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Inputs
{
    public class JoystickInput : MonoBehaviour
    {
        [SerializeField] Joystick _floatingJoystick;
        Vector3 _movementVector;
        Vector3 _rotationVector;
        public Vector3 MovementVector => _movementVector;
        public Vector3 RotationVector => _rotationVector;

        void FixedUpdate()
        {
            _movementVector = InitMoveVector();
            _rotationVector = InitRotateVector();
        }

        private Vector3 InitMoveVector()
        {
            if (!GameManager.Instance.isGameStart)
            {
                _movementVector = Vector3.zero;
            }
            if(_movementVector == Vector3.zero)
            {
                _movementVector = Vector3.forward;
            }
            if(_floatingJoystick.Horizontal != 0 && _floatingJoystick.Vertical != 0)
            {
                _movementVector = Vector3.zero;
                _movementVector.x = _floatingJoystick.Horizontal * Time.deltaTime;
                _movementVector.z = _floatingJoystick.Vertical * Time.deltaTime;
                _movementVector = _movementVector.normalized;
            }
            else
            {
                _movementVector = _movementVector;
            }
            return _movementVector;
        }
        private Vector3 InitRotateVector()
        {
     
            if (_floatingJoystick.Horizontal != 0 && _floatingJoystick.Vertical != 0)
            {
                _rotationVector = Vector3.zero;
                _rotationVector.z = _floatingJoystick.Horizontal;
            }
            else
            {
                _rotationVector = Vector3.zero;
            }
            return _rotationVector;
        }
    }
}