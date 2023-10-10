using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private int _scaleSpeed;
    [SerializeField] private Camera _camera;

    [SerializeField] private int _rangeCamMAX;
    [SerializeField] private int _rangeCamMIN;


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

        if (Input.GetKey(KeyCode.W) && _camera.transform.position.z < -1* _rangeCamMIN)
        {
            ScaleCam(1);
        }

        if (Input.GetKey(KeyCode.S) && _camera.transform.position.z > -1*_rangeCamMAX)
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



