using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableEnemy : Enemy
{
    [SerializeField]
    private float rate = 2.0f;
    private Fire fire;

    private int Lives = 2;
    private SpriteRenderer sprite;
    BoxCollider2D box;

    AudioSource Audio;

    new private Rigidbody2D rigidbody;


    protected override void Awake()
    {
        fire = Resources.Load<Fire>("Fire");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
        Audio = GetComponent<AudioSource>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }


    private void Shoot()
    {
        Vector3 position = transform.position;      position.y += 0.25f;
        Fire newFire = Instantiate(fire, position, fire.transform.rotation) as Fire;

        newFire.Parent = gameObject;
        newFire.Direction = -newFire.transform.right;
        
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5f)
            {
                Lives--;
            }
            else
            {
               
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(transform.up * 10.0f, ForceMode2D.Impulse);
                unit.ReceiveDamage();
            }
        }

        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            Lives--;
        }
        if (Lives == 0)
        {
            Destroy(sprite);
            Destroy(box);
            Destroy(gameObject, 0.2f);
            Audio.PlayOneShot(Audio.clip);
        }

    }
}
