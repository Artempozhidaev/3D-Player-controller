using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void LateUpdate()
    {
        var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(Ray, out hit);

        Vector3 v3 = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        transform.LookAt(v3);

        transform.Rotate(90,0,0,Space.Self);
        transform.Rotate(0,-90,0,Space.Self);
        transform.Rotate(-20,0,0,Space.Self);

    }
}
