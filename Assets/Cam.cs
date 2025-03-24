using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject target;
    private Camera cam;
    private float mouseSpeed = 200f;
    private float xrot;
    private float yrot;

    private void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        xrot -= mouseY;
        yrot += mouseX;

        xrot = Mathf.Clamp(xrot, -70f, 70f);

        //보통 회전을 표현할때 Quaternion을 사용함
        //Quaternion.Euler 함수는 각도를 쿼터니언으로 변환해줌
        cam.transform.rotation = Quaternion.Euler(xrot, yrot, 0);
        target.transform.rotation = Quaternion.Euler(0, yrot, 0);
    }
}