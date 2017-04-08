using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRand : MonoBehaviour {

    public GameObject[] EnemyGo;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
	public float timer;

    int randEnemy;

    public float Timer
    {
        get
        {

            return this.timer;
        }
        set
        {
            this.timer = value;

        }

    }

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
		timer += Time.deltaTime;
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        while (!stop)
        {
            if (timer<10f)
            {
                randEnemy = 0;
            }
            else if (timer<20f)
            {
                randEnemy = 1;
            }
            else if (timer<30)
            {
                randEnemy = 2;
            }
            else if (timer<40f)
            {
                randEnemy = 3;
            }
            else if (timer<50)
            {
                randEnemy = Random.Range(0, EnemyGo.Length);
            }
			GameObject enemy = (GameObject)Instantiate(EnemyGo[randEnemy]);
			Vector2 spawnPosition = new Vector2(Random.Range(min.x, max.x), max.y);
			enemy.transform.position = spawnPosition;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
