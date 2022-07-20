using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movment : MonoBehaviour
{
    public Transform PlayerPosition;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerPosition.position;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(PlayerPosition.position.x + offset.x,transform.position.y,PlayerPosition.position.z + offset.z);
    }
}
