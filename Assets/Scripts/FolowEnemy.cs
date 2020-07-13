using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowEnemy : MonoBehaviour
{
    public Transform enemyPosition;

   
    void Update()
    {
        if (enemyPosition != null)
        {
            transform.position = enemyPosition.position;
        }

    }
}
