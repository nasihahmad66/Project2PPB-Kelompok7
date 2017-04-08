using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //inisialisasi peluru
    public GameObject GameManagerGO;

    public GameObject PlayerBulletGo;
    public GameObject playerBullet01;
    public GameObject playerBullet02;
    public GameObject ExplosionGo;
    
    float sentuhan;
	public AudioClip audioClip;

    public Text LivesTextUI;
    const int MaxLives = 3;
    int Lives;
    
    public float speed;
    //float AccelStarY;

    public void Init()
    {
        Lives = MaxLives;
        LivesTextUI.text = Lives.ToString();
        gameObject.SetActive(true);
    }
    void Start ()
    {
        //AccelStarY = Input.acceleration.y;
	}
	
	void Update ()
    {
        if (Input.touchCount==1)
        {
         sentuhan += 1;
        }
        else
        {
            sentuhan = 0;
        }

        //jika ada input untuk menembak
        if (sentuhan%9==1)
        {
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGo);
            bullet01.transform.position = playerBullet01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGo);
            bullet02.transform.position = playerBullet02.transform.position;

			GetComponent<AudioSource>().PlayOneShot(audioClip);
        }

        float x= Input.acceleration.x;
        float y= Input.acceleration.y;

        Vector2 direction = new Vector2(x, y);
        if (direction.sqrMagnitude>1)
        {
            direction.Normalize();
        }

        move(direction);
    }

    void move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed*Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag=="EnemyTag")||(col.tag=="EnemyBulletTag"))
        {
            PlayExplosion();
            Lives--;
            LivesTextUI.text = Lives.ToString();
            if (Lives==0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
            
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);
        explosion.transform.position = transform.position;
    }
}
