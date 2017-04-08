using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Use this for initialization
	public GameObject ScoreUITextGO;
    float speed;
    public GameObject explosionGO;
    void Start () {
        speed = 2f;

        ScoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextUI");    
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerTag") || (col.tag == "PlayerBulletTag"))	
        {
			
            PlayExplosion();
            ScoreUITextGO.GetComponent<GameScore>().Score += 50;
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionGO);
        explosion.transform.position = transform.position;
    }
}
