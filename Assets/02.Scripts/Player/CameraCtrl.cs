using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    Camera cam;
    Transform tr;

    float mouseSensitivity = 2.0f;  // 마우스 감도
    float YLimit = 60f;             // 카메라 수직 회전 제한

    private float rotX = 0.0f;   // 수평 회전 값
    private float rotY = 0.0f;    // 수직 회전 값

    float mouseX => Input.GetAxis("Mouse X") * mouseSensitivity;
    float mouseY => Input.GetAxis("Mouse Y") * mouseSensitivity;

    void Start()
    {
        Cursor.visible = false;
        cam = Camera.main;
        tr = transform;
    }

    void Update()
    {
        rotX += mouseX;
        rotY -= mouseY;
        rotY = Mathf.Clamp(rotY, -YLimit, YLimit);

        cam.transform.rotation = Quaternion.Euler(rotY, rotX, 0);
        cam.transform.position = tr.position + Vector3.up * 2f;
        tr.rotation = Quaternion.Euler(0, rotX, 0);
    }
}
