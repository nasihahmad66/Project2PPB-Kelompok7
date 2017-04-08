using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour {
	public GameObject explosionGO;
	float speed;
	Vector2 _direction;
	bool isReady;
	void Awake(){
		speed = 5f;
		isReady = false;
	}
	void Start () {
		
	}

	public void SetDirection(Vector2 direction){
		_direction = direction.normalized;
		isReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			Vector2 Position = transform.position;
			Position += _direction * speed * Time.deltaTime;
			transform.position = Position;

			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 2));
			if ((transform.position.x < min.x)||(transform.position.x > max.x)||
				(transform.position.y < min.y)||(transform.position.y > max.y)) {
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "PlayerTag") || (col.tag == "PlayerBulletTag"))	
		{

			PlayExplosion();
			Destroy(gameObject);


		}
	}
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate(explosionGO);
		explosion.transform.position = transform.position;
	}
}
