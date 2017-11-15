using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    public float destroy;
    public float speed = 15.0f;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    private Character character;

    BossScript boss;
    Bullet bullet;

    private void Start()
    {
        boss = GetComponent<BossScript>();
        bullet = GetComponent<Bullet>();
        Destroy(gameObject, 20);
    }


    

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        ShootableEnemy enemy = collider.GetComponent<ShootableEnemy>();
        ShootableEnemy1 enemy1 = collider.GetComponent<ShootableEnemy1>();
        MandShootEnemy enemy2 = collider.GetComponent<MandShootEnemy>();

        if (unit is Character)
        {
            unit.ReceiveDamage();
            Destroy(gameObject);
        }

        if (unit is Character)
        {
            Destroy(gameObject);
        }
    }
    

}
