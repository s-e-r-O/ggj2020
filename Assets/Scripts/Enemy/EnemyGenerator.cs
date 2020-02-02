﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public List<Transform> entrances;
    public GameObject enemyPrefab;
    public float seconds;
    public int numberOfEnemiesSpawned;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);

            for (int i = 0; i < numberOfEnemiesSpawned; i++)
            {
                int index = Random.Range(0, entrances.Count);

                var obj = Instantiate(enemyPrefab, entrances[index].position, entrances[index].rotation);

                EnemyMovement enemy = obj.GetComponent<EnemyMovement>();
                enemy.direction = entrances[index].position.x > 0 ? Vector2.left : Vector2.right;
            }
        }
    }
}