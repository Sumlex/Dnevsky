using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Character : Unit
{
    public GameObject Vspishka;
    public GameObject Activator;
    public GameObject Restart;
    public GameObject CheckPoint;
    public GameObject CheckPoint1;

    float timer = 0;

    [SerializeField]
    private int lives = 4;
    public int Hearts = 2;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    public int score;

    private float SpawnX, SpawnY;
    public int Level;
    EscapeScript escape;
    

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float JumpForce = 15.0f;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private bool isgrounded = false;

    private Bullet bullet;
    AudioSource Audio;

    CheckPoint checkpoint;

    MoveableGround move;

    private CharState State
            {
                get { return (CharState)animator.GetInteger("State"); }
                set { animator.SetInteger("State", (int) value); }
            }
    private void Start()
    {
        SpawnX = transform.position.x;
        SpawnY = transform.position.y;

        Level = 1;
        livesBar.Refresh();
        Audio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
                sprite = GetComponentInChildren<SpriteRenderer>();
                    bullet = Resources.Load<Bullet>("Bullet");
                        move = GetComponentInChildren<MoveableGround>();
                            checkpoint = GetComponent<CheckPoint>();
                                 Level = 1;
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    // таймер перезарядки
    float reloadtimer;
    float LiveEater;
    //

    private void Update()
    {
        // время для перезарядки
        reloadtimer -= Time.deltaTime;
        //
        LiveEater -= Time.deltaTime;
       
        if (isgrounded) State = CharState.Idle;

        if (Input.GetButtonDown("Fire1") && reloadtimer <= 0)
            {
                Shoot();
                Attack();
                reloadtimer = 0.4f;
            }

        if (Input.GetButton("Horizontal")) Run();

        if (isgrounded && Input.GetButtonDown("Jump")) jump();
            
        if (LiveEater > 0)
        {
            immortal();
        }

        if(Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Level);
        }

        //////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////

    }

  

    private void immortal()
    {
        State = CharState.Immortal;
    }

    private void Run()
    {
        if (isgrounded) State = CharState.Walk;
            Vector3 direction = transform.right * Input.GetAxis("Horizontal");

                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

                    sprite.flipX = direction.x < 0.0f;
    }

    private void jump()
    {
        
        rigidbody.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);

    }

    //Выстрел патронами
            private void Shoot()
            {
        
                 Vector3 position = transform.position; position.y += 1.2f; position.x +=0.2f ;
                   Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;//Создание выстрела в сцене

                     newBullet.Parent = gameObject;
                        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0f : 1.0f);      
            }

    private void Attack()
    {
        State = CharState.Attack;
    }

    private void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
            isgrounded = colliders.Length > 1;
                if (!isgrounded) State = CharState.Jump; 
    }

    public override void ReceiveDamage()
    {
        if (LiveEater <= 0)
        {
            Lives--;

            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 8.0f, ForceMode2D.Impulse);
            
            Debug.Log(lives);
            LiveEater = 1.0f;
            Audio.PlayOneShot(Audio.clip);

        }
        
        if (lives <= 0)
        {
            Hearts--;
            lives = 4;
            livesBar.Refresh();
            if (Level == 2 && CheckPoint.activeSelf == true)
            {
                CheckPoint.SetActive(true);
                CheckPoint1.SetActive(false);

                SpawnX = 86.44f;
                SpawnY = 7.02f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }

            else if (Level == 1 && CheckPoint.activeSelf == true)
                {
                    SpawnX = 12.14f;
                    SpawnY = 40.15f;
                    transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
                }
            else if (Level == 1 && CheckPoint.activeSelf ==false)
            {
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }
            
            

            if (Level == 2 && CheckPoint1.activeSelf == true || (Level == 2 && (CheckPoint.activeSelf == true) && (CheckPoint1.activeSelf == true)))
            {
                CheckPoint.SetActive(false);
                CheckPoint1.SetActive(true);

                SpawnX = 129.27f;
                SpawnY = -5.96f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }

            if (Level == 3 && CheckPoint.activeSelf == true)
            {
                Activator.SetActive(true);
                SpawnX = 51.13f;
                SpawnY = -2.96f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }
            else if (Level == 3 && CheckPoint.activeSelf == false)
            {
                Restart.SetActive(true);
                SpawnX = -2.9f;
                SpawnY = -3.96f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }
            else transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
        }

        if (Hearts <= 0)
        {
            die();
        }

}
    public void die()
    {
        livesBar.Refresh();
    }
       private void OnGUI()
      {
        GUI.Box(new Rect(96, 10, 25, 20), "X" + Hearts);
      }

    private void OnTriggerEnter2D (Collider2D collider)
    {
        Unit unit = collider.gameObject.GetComponent<Unit>();
        if (unit && !(unit is ShootableEnemy) && !(unit is MoveEnemy))   ReceiveDamage();
        

        if(unit && (unit is ShootableEnemy) || (unit is MoveEnemy))
        {
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(transform.up * 8.0f, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BossPortal")
        {
            SceneManager.LoadScene(4);
        }
        if (collision.gameObject.name == "Dver")
        {
            SceneManager.LoadScene(5);
        }

        if (collision.gameObject.tag == "Dead")
        {
            ReceiveDamage();
            SpawnX = 324.8f;
            SpawnY = 193.9f;
            transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
        }


        if (collision.gameObject.name == "saw")
        {
            ReceiveDamage();
        }

        if(collision.gameObject.name == "DieCollider")
        {
            if (Level == 2 && CheckPoint.activeSelf == true)
            {
                CheckPoint.SetActive(true);
                CheckPoint1.SetActive(false);

                SpawnX = 86.44f;
                SpawnY = 7.02f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }

            else if (Level == 1 && CheckPoint.activeSelf == true)
            {
                SpawnX = 12.14f;
                SpawnY = 40.15f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }


            if (Level == 2 && CheckPoint1.activeSelf == true || (Level == 2 && (CheckPoint.activeSelf == true) && (CheckPoint1.activeSelf == true)))
            {
                CheckPoint.SetActive(false);
                CheckPoint1.SetActive(true);

                SpawnX = 129.27f;
                SpawnY = -5.96f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }

            if (Level == 3 && CheckPoint.activeSelf == true)
            {
                Restart.SetActive(false);
                Activator.SetActive(true);
                SpawnX = 51.13f;
                SpawnY = -2.96f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }
            else if (Level == 3 && CheckPoint.activeSelf == false)
            {
                Restart.SetActive(true);
                SpawnX = -2.9f;
                SpawnY = -3.96f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }
            else if (Level == 3 && (CheckPoint.activeSelf == true) && (Restart.activeSelf == true))
            {
                SpawnX = 51.13f;
                SpawnY = -2.96f;
                transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            }

            else transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);

            ReceiveDamage();
        }

        if(collision.gameObject.name == "EndLevel")
        {
            Level++;

            SceneManager.LoadScene(Level);
        }

        if (collision.gameObject.name == "Portal")
        {
            Level = 3;
            SceneManager.LoadScene(Level);
        }
        if (Level == 2 && collision.gameObject.name == "PortalInLevel")
        {
            Vspishka.SetActive(true);
            Destroy(Vspishka, 1.2f);
            Destroy(collision.gameObject);
            SpawnX = 52.9f;
            SpawnY = -2.89f;

            transform.position =new Vector3(SpawnX, SpawnY, transform.position.z);
        }
        if (collision.gameObject.name == "NewLevel")
        {
            Level++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Level3 increment")
        {
            Level = 3;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Boss increment")
        {
            Level = 4;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Boss")
        {
            Hearts = 0;
            Lives = 0;
        }

    }
    public enum CharState
    {
        Idle, Walk, Jump, Attack, Immortal
    }
}
