using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Movements
{
    public class PlayerMovement : MonoBehaviour
    {
        Transform _transform;
        float _speed;
        Rigidbody _rb;
        float _rotateSpeed;

        public PlayerMovement(Transform transform, float speed,Rigidbody rb, float rotateSpeed)
        {
            _transform = transform;
            _speed = speed;
            _rb = rb;
            _rotateSpeed = rotateSpeed;
        }

        public void Move(Vector3 moveVector)
        {
            Vector3 direction = Vector3.RotateTowards(_transform.forward, moveVector, 10 * Time.deltaTime, 0.0f);
            _transform.rotation = Quaternion.LookRotation(direction * Time.deltaTime * _speed);
            _rb.MovePosition(moveVector.normalized * Time.deltaTime * _speed + _rb.position);

        }
    }
}