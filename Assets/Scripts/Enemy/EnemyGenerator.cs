using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public List<Transform> entrances;
    public GameObject enemyPrefab;
    public int difficulty = 0;
    public int enemiesLife = 100;
    public int enemiesDamage = 25;
    public List<float> secondsDifficulty;
    public List<float> secondsBetweenEnemiesDifficulty;
    public List<int> numberOfEnemiesSpawnedDifficulty;
    public List<int> numberOfentrancesDifficulty;
    public AudioSource explosion;

    

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
            yield return new WaitForSeconds(secondsDifficulty[difficulty]);

            for (int i = 0; i < numberOfEnemiesSpawnedDifficulty[difficulty]; i++)
            {
                int index = Random.Range(0, numberOfentrancesDifficulty[difficulty]);

                var obj = Instantiate(enemyPrefab, entrances[index].position, entrances[index].rotation);
                obj.GetComponent<Enemy>().explosion = explosion;
                obj.GetComponent<Enemy>().health = enemiesLife;
                obj.GetComponent<Enemy>().ModifyDamage(enemiesDamage);

                EnemyMovement enemy = obj.GetComponent<EnemyMovement>();
                enemy.direction = entrances[index].position.x > 0 ? Vector2.left : Vector2.right;
                yield return new WaitForSeconds(secondsBetweenEnemiesDifficulty[difficulty]);
            }
        }
    }

    public void Hardeeer()
    {
        difficulty = Mathf.Min(secondsDifficulty.Count-1, difficulty + 1);
    }

    public void StrongerEnemies()
    {
        enemiesLife += 25;
        enemiesDamage += 10;
    }
}
