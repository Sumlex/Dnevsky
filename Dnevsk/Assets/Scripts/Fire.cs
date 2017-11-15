using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private float speed = 15.0f;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    private Character character;

   

    private void Start()
    {
        Destroy(gameObject, 0.5F);
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

        if (!enemy && !enemy1 && !enemy2)
        {
            Destroy(gameObject);
        }
    }


}
