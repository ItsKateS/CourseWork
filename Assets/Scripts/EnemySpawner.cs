using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform target;
    public GameObject enemy;

    float spawnTime = 5f;
    float minimalSpawnTime = 1f;
    float currentTime = 0f;

    public GameObject panel;

    void LateUpdate()
    {
        currentTime += Time.deltaTime;

        if(currentTime > spawnTime)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-15, 16), 0, Random.Range(-15, 6));

            GameObject enemyClone = Instantiate(enemy, randomSpawnPosition, Quaternion.identity);
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Enemy"); 
            int count = 0;
            foreach (GameObject clone in clones)
            {
                count++;

                if (count > 50)
                    panel.SetActive(true);
            }

            EnemyController enemyController = enemyClone.GetComponent<EnemyController>();
            enemyController.target = target;

            currentTime = 0f;

            if (spawnTime > minimalSpawnTime)
                spawnTime -= .1f;
            else
                spawnTime = minimalSpawnTime;
        }
    }
}
