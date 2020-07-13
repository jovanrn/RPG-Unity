using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static int numberOfEnemies = 1;
    public GameObject enemyPrefab;
    public Transform position;
    public GameObject effect;
    public Transform effectPostion;


    private void Update()
    {
        if (numberOfEnemies <= 0)
        {
            Invoke("spawn", 2f);
            ++numberOfEnemies;
        }
    }

    public void spawn()
    {
        Instantiate(effect, effectPostion.position, Quaternion.identity);
        Instantiate(enemyPrefab, position.position, Quaternion.identity);
    }

}
