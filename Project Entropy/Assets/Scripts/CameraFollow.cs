using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float camMoveSpeed = 3f;
    void Update()
    {
        Vector3 camFollowPos = target.position;
        camFollowPos.z = transform.position.z;
        Vector3 camFollowDir = (camFollowPos - transform.position).normalized;
        float dist = Vector3.Distance(camFollowPos, transform.position);

        transform.position = transform.position + camFollowDir * dist * camMoveSpeed * Time.deltaTime;
    }
}
