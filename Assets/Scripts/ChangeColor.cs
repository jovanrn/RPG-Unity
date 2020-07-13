using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public  Material outside;
    public float speed=1.0f;
    public Color StartColor;
    public Color EndColor;
    Color temp;
    public bool repeatable = false;
    float startTime;


    private void Start()
    {
        startTime = Time.deltaTime;
    }


    public void FixedUpdate()
    {
        /*
          if (!repeatable)
          {
              float t = (Time.time - startTime) * speed;
              outside.color = Color.Lerp(StartColor, EndColor,t);
          }
          else
          {
              float t = (Mathf.Sin(Time.time - startTime) * speed);
              outside.color = Color.Lerp(StartColor, EndColor, t);

          }
      **/

        outside.color = Color.Lerp(StartColor, EndColor,Mathf.Sin((Time.time- startTime*2)*6));


    }

}
