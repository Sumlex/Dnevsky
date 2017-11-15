using UnityEngine;
using System.Collections;

public class Bossik : MonoBehaviour
{

    public Transform player;
    public float move_speed;
    public float rotation_speed;
    public Transform enemy;
    void Update()
    {
        var look_dir = player.position - enemy.position;
        look_dir.y = 0;
      
        enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
        enemy.position += enemy.forward * move_speed * Time.deltaTime;


    }
}




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bossik : Enemy
{
    [SerializeField]
    private float rate = 2.0f;
    private Fire fire;

    public int Lives = 10;

    public float speed = 2.0f;

    private SpriteRenderer sprite;
    private Vector3 direction;
    public GameObject stupen;
    Character character;


    AudioSource Audio;
    BoxCollider2D box;

    new private Rigidbody2D rigidbody;

    protected override void Update()
    {
        Move();
    }

    protected override void Awake()
    {
        fire = Resources.Load<Fire>("Fire");
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        character = GetComponent<Character>();
    }

    protected override void Start()
    {
        direction = transform.right;
        InvokeRepeating("Shoot", rate, rate);
        Audio = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider2D>();
    }


    private void Shoot()
    {
        Vector3 directions = stupen.transform.localPosition;
        Vector3 position = transform.position; position.y += 0.75f;
        Fire newFire = Instantiate(fire, position, fire.transform.rotation) as Fire;

        newFire.Parent = gameObject;
        newFire.Direction = directions;

    }
    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.6f, 0.1f);
        if (colliders.Length > 1 && (colliders.All(x => !x.GetComponent<Character>() && !x.GetComponent<Fire>()))) direction *= -1.0f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x > 0.0f;

    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 10.0f, ForceMode2D.Impulse);
            unit.ReceiveDamage();
        }

        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            Lives--;
            if (Lives == 0)
            {
                Destroy(gameObject);
                Audio = GetComponent<AudioSource>();
                sprite = GetComponentInChildren<SpriteRenderer>();
                box = GetComponent<BoxCollider2D>();
            }
        }


    }
}
*/
