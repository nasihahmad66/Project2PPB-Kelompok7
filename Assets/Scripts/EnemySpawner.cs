using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // Use this for initialization
    public GameObject EnemyGo;

    float maxSpawnRateInSeconds = 5f;

    void Start () {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("incraseSpawnrate", 0f, 30f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject enemy = (GameObject)Instantiate(EnemyGo);
		enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleToSpawnEnemy();
    }
    void ScheduleToSpawnEnemy()
    {
        float SpawnInSecond;

        if (maxSpawnRateInSeconds > 1f)
        {
            SpawnInSecond = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            SpawnInSecond = 1f;
        }
        Invoke("SpawnEnemy", SpawnInSecond);
    }
    void incraseSpawnrate()
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("incraseSpawnrate");
        }
    }
    public void SceduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("incraseSpawnrate", 0f, 30f);
    }

    public void UnsceduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("incraseSpawnrate");
    }
}
