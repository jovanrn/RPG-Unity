using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Camera camera;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {   
        // pozicija strelice(cursor)

        Vector3 cursorPos = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f,0f,4f));
        Debug.Log(cursorPos);
        transform.position = cursorPos;
    }



}
