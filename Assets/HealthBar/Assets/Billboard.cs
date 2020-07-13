using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    private Camera came;

    private void Start()
    {
        came = Camera.main;
        cam = came.transform;
    }


    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
