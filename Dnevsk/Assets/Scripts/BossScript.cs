using System.Collections;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform[] spots;
    public float speed;
    public GameObject Ammo;

    GameObject Player;

    public GameObject Dver;

    public Transform[] holes;

    private Animator animator;
    Vector3 PlayerPos;

    public Sprite[] sprites;
    public bool Zloy;

    public float Lives = 100;



    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("boss");
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }


    IEnumerator boss()
    {
        while(true)
        {
            //First Attack
            while (transform.position.x != spots[0].position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, transform.position.y), speed);

                yield return null; // Затем поменяю на анимацию
            }

            transform.localScale = new Vector2(-1, 1);

            yield return new WaitForSeconds(1f);

            int i = 0;
            while (i < 10)
            {
                GameObject bullet = (GameObject)Instantiate(Ammo, holes[(Random.Range(0, 2))].position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 6;



                i++;
                yield return new WaitForSeconds(.8f);
            }


            // Second Attack
            GetComponent<Rigidbody2D>().isKinematic = true;

            while (transform.position != spots[2].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, spots[2].position, speed);

                yield return null;
            }

            //падение на персонажа
            PlayerPos = Player.transform.position;

            yield return new WaitForSeconds(1f);
            GetComponent<Rigidbody2D>().isKinematic = false;

            //движение в сторону персонажа
            while (transform.position.x != PlayerPos.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerPos.x, transform.position.y), speed);

                yield return null; // Затем поменяю на анимацию
            }
            this.tag = "Untagged";
            GetComponent<SpriteRenderer>().sprite = sprites[1];

            Zloy = true;
            yield return new WaitForSeconds(4);
            this.tag = "Dead";
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            Zloy = false;

            //Third Attack
            Transform temp;
            if (transform.position.x > Player.transform.position.x)
            {
                temp = spots[1];
            }
            else
                temp = spots[0];

            while (transform.position.x != temp.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, transform.position.y), speed);

                yield return null; // Затем поменяю на анимацию
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            Lives -= 4;
            if (Lives <= 0)
            {
                Destroy(gameObject);
                Dver.SetActive(true);
            }
        }


    }
}
