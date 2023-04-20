using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] int _attack;
    [SerializeField] Transform _player;
    [SerializeField] GameObject _uiPanel;
    public bool isGameOver = false;
   // [SerializeField] GameObject _option;

    Rigidbody2D rigid;
    Animator _ani;
    
    GameObject _border;
    public GameObject _scanObject;
    public GameManager manager;
    public Monster monster;

    OpenStone _openStone;

    public bool BossRoom;
    public bool BossClear;
    public bool goMain;
    public bool goMain1;

    //현재 바라보고 있는 방향 값을 가진 변수가 필요
    Vector3 dirVec;

    //bool isIdle = true;

    public void Hitted(int dmg)
    {
        if (_hp < 0) return;
        _hp -= dmg;
        if (_hp < 0)
        {
            //Game over
            isGameOver = true;
            _uiPanel.SetActive(true);
            this.gameObject.SetActive(false);

        }
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        

    }
    void Update()
    {
        //Dungeon>>main

        //house>>main
        if (goMain1 == true)
        {
            transform.position = new Vector3(11.47f, 0.67f, 0);
        }
        
        move();


        RayCast();

        
    }

   public void RayCast()
    {
        //스캔할 수 있다
        Debug.DrawRay(rigid.position, dirVec * 0.8f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.8f, 1 <<LayerMask.NameToLayer("Object"));

        if (rayHit.collider != null)
        {
            _scanObject = rayHit.collider.gameObject;
        }
        else
        {
            return; 
        }
        if (Input.GetKeyDown(KeyCode.Space)&&_scanObject!=null&&_scanObject.GetComponent<objData>()!=null)
        {
            manager.Action(_scanObject);
        }

        if(Input.GetKeyDown(KeyCode.Space)&& _scanObject.tag== "Stone")
        {
            _scanObject.GetComponent<OpenStone>().isPlayerEnter = true;
        }

    }
   




    public void move()
    {
        if(isGameOver) { return; }
        if (manager.isAction || manager._Action) return;

        Vector2 v2 = Vector2.zero;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirVec = Vector3.right;
            _ani.SetInteger("move", 1);
            transform.Translate(Vector2.right * Time.deltaTime * _speed);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _ani.SetInteger("move", 2);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirVec = Vector3.left;
            _ani.SetInteger("move", 3);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _ani.SetInteger("move", 4);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            dirVec = Vector3.up;
            _ani.SetInteger("move", 5);
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _ani.SetInteger("move", 6);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            dirVec = Vector3.down;

            _ani.SetInteger("move", 7);
            transform.Translate(Vector2.down * Time.deltaTime * _speed);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _ani.SetInteger("move", 0);
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DungeonDoor")
        {
            SceneManager.LoadScene("Dungeon");
        }
        if (collision.gameObject.tag == "Border")//Dungeon>>main
        {
            SceneManager.LoadScene("Main");
            goMain = true;
            goMain1 = false;
           
            
        }
        if (collision.gameObject.tag == "Border1")//house>>main
        {
            SceneManager.LoadScene("Main");
            goMain1 = true;
            goMain = false;

        }
        if (collision.gameObject.tag== "HouseDoor1")
        {
            SceneManager.LoadScene("House1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossRoom")
            BossRoom = true;
        if (collision.gameObject.tag == "BossClear")
            BossClear = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossRoom")
            BossRoom = false;
        if (collision.gameObject.tag == "BossClear")
            BossClear = false;
    }


}