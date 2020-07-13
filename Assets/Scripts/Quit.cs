using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject audioOff;
    public GameObject theme;
    public void kraj()
    {
        DestroyImmediate(theme);
        DestroyImmediate(audioOff);
        gameObject.SetActive(true);
        Invoke("nesto", 4f);

    }

    public void nesto()
    {
        Debug.Log("We quit");
        Application.Quit();
    }
}
