using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private int _scaleSpeed;
    [SerializeField] private Camera _camera;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                _rigidbody.AddTorque(Vector3.up * torque);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rotation(-1);
        }


        if (Input.GetKey(KeyCode.D))
        {
            Rotation(1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            ScaleCam(1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ScaleCam(-1);
        }


    }

    private void Rotation(int rightRot)
    {
        _rigidbody.AddTorque(Vector3.up * Time.deltaTime * _rotateSpeed * rightRot);

    }

    private void ScaleCam(int upScale)
    {
        _camera.transform.Translate(new Vector3(0, 0, upScale*_scaleSpeed) * Time.deltaTime, Space.Self);
    }
}



