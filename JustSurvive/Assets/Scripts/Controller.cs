using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private string RotateAxisName = "Horizontal";
    private string MoveAxisName = "Vertical";

    private string MouseRotateXName = "Mouse X";
    private string MouseRotateYName = "Mouse Y";

    public float X { get; private set; }
    public float Z { get; private set; }

    public float MouseX { get; private set; }
    public float MouseY { get; private set; }

    float rotationX;
    float rotationY;
    public float rotSpeed = 200f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        X = Z = 0f;

        X = Input.GetAxis(RotateAxisName);
        Z = Input.GetAxis(MoveAxisName);

        MouseX = Input.GetAxisRaw(MouseRotateXName);
        MouseY = Input.GetAxisRaw(MouseRotateYName);

        //rotationX += rotSpeed * MouseY * Time.deltaTime;
        //rotationY += rotSpeed * MouseX * Time.deltaTime;

        //rotationX = Mathf.Clamp(rotationX, -30f, 30f);

        //transform.eulerAngles = new Vector3(-rotationX, rotationY, 0f);
    }
}