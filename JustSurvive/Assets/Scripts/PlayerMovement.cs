using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Controller _controller;
    private Rigidbody _rigidbody;

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    [SerializeField] float _rotationSpeed = 200f;
    [SerializeField] private float _moveSpeed = 10f;

    void Start()
    {
        _controller = GetComponent<Controller>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        ViewRotation();
    }

    /// <summary>
    /// 마우스를 통해 볼 수 있는 시야각
    /// </summary>
    private void ViewRotation()
    {
        _rotationX += _rotationSpeed * _controller.MouseY * Time.deltaTime;
        _rotationY += _rotationSpeed * _controller.MouseX * Time.deltaTime;

        // 위 아래를 보는 시야각에 제한을 줌
        _rotationX = Mathf.Clamp(_rotationX, -30f, 30f);

        // 회전 적용
        transform.eulerAngles = new Vector3(-_rotationX, _rotationY, 0f);
    }

    /// <summary>
    /// 플레이어 이동 
    /// </summary>
    private void Move()
    {
        Vector3 dir = Vector3.right * _controller.X + Vector3.forward * _controller.Z;

        // 메인 카메라(플레이어 뷰)의 시점에서 이동해야 할 방향을 구함
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0f;
        //dir.Normalize();

        _rigidbody.MovePosition(transform.position + dir * _moveSpeed * Time.deltaTime);
    }
}
