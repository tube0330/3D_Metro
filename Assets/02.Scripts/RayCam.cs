using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCam : MonoBehaviour
{
    Transform tr;
    Color rayColor = Color.blue;
    float rayLength = 5f;

    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(tr.position, tr.forward, out hit, rayLength))
        {
            // 감지된 장애물이 있을 경우
            if (hit.collider != null)
            {
                Debug.Log("장애물 감지: " + hit.collider.name);
                Debug.DrawRay(tr.position, tr.forward * rayLength, rayColor);
            }
        }

        //Draw raycast
        Debug.DrawRay(tr.position, tr.forward * rayLength, Color.red);
    }
}
