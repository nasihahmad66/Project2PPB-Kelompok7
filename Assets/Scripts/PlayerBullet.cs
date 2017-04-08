using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    // Use this for initialization
    float speed;
	void Start () {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
        //mengatur pergerakan peluru
        //get posisis awal peluru
        Vector2 position = transform.position;
        //menghitung posisi baru peluru
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        //posisi baru peluru
        transform.position = position;

        //mengatur agar peluru ter destroy setelah melewati frame
        //pojok atas frame
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        //pengkondisian
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyTag") || (col.tag == "EnemyBulletTag"))
        {
            Destroy(gameObject);
        }
    }
}
