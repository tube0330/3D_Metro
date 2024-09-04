using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float moveSpeed = 2.0f;  // 속도
    float jumpForce = 3.0f; // 점프 파워
    float gravity = -10f;   // 중력 값, 높인 중력으로 설정
    private Vector3 moveDir;

    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 지면에 닿아 있는지 확인
        bool isGrounded = cc.isGrounded;

        if (!isGrounded)
            moveDir.y += gravity * Time.deltaTime;

        else
        {
            if (moveDir.y < 0)  //떨어지는중
                moveDir.y = -0.1f; //중력으로 인한 물리적 상호작용을 정확하게 감지하기 위해, 아주 작은 음수 값을 사용
        }

        // 이동 처리
        cc.Move(moveDir * moveSpeed * Time.deltaTime);
    }

    public void Move(Vector3 dir)
    {
        // 수평 이동만 처리
        moveDir.x = dir.x;
        moveDir.z = dir.z;
    }

    public void Jump()
    {
        if (cc.isGrounded)
        {
            // 지면에 있을 때 점프
            moveDir.y = jumpForce;
        }
    }
}
