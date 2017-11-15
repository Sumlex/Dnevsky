using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveEnemy : Enemy
{

    [SerializeField]
    private float speed = 2.0f;

    private SpriteRenderer sprite; 

    //private Bullet bullet;

    private Vector3 direction;

    AudioSource Audio;
    BoxCollider2D box;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
       // bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        direction = transform.right;
        Audio = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider2D>();
    }

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.7f)
            {
                Destroy(gameObject, 0.02f);
                Audio.PlayOneShot(Audio.clip);
            }
            else unit.ReceiveDamage();
        }
    }
    
    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.6f, 0.1f);
        if (colliders.Length > 0 && (colliders.All(x => !x.GetComponent<Character>() && !x.GetComponent<Fire>()))) direction *= -1.0f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x > 0.0f;
    }

}
