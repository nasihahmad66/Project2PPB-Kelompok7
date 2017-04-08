using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
	public GameObject EnemyBulletGo;

	// Use this for initialization
	void Start () {
		Invoke ("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FireEnemyBullet(){
		GameObject Player = GameObject.Find ("PlayerGO");
		if (Player != null) {
			GameObject bullet = (GameObject)Instantiate (EnemyBulletGo);
			bullet.transform.position = transform.position;
			Vector2 direction = Player.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyBullets> ().SetDirection (direction);
		}
	}
}
