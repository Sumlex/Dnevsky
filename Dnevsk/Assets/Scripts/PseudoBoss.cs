using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PseudoBoss : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    private Vector3 direction;

    private SpriteRenderer sprite;

    Character character;
    public GameObject Save;
    public GameObject Restart;

    private float SpawnX, SpawnY;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        character = GetComponent<Character>();
    }

    private void Start()
    {
        direction = transform.right;
        sprite = GetComponentInChildren<SpriteRenderer>();
        SpawnX = transform.position.x;
        SpawnY = transform.position.y;
    }

    private void Update()
    {
        Move();

        if (Save.activeSelf == true)
        {
            Save.SetActive(false);
            SpawnX = 22.34f;
            SpawnY = -15f;
            transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
        }
        else if (Restart.activeSelf == true)
        {
            Restart.SetActive(false);
            SpawnX = -29.2f;
            SpawnY = -15.2f;
            transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.6f, 0.1f);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
