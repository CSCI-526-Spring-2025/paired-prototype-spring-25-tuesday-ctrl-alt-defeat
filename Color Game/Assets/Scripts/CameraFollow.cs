using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    
    void Start()
    {
        Camera.main.aspect = (float)Screen.width / Screen.height;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {

            transform.position = target.position + offset;
            Camera.main.aspect = (float)Screen.width / Screen.height;
        }
}
}
