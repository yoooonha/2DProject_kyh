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
    [SerializeField] GameManager manager;
    [SerializeField] Monster monster;
    Rigidbody2D rigid;
    Animator _ani;
    GameObject _border;
    GameObject _scanObject;
    OpenStone _openStone;
    bool isGameOver = false;
    protected bool _bossRoom;
    public bool BossRoom { get { return _bossRoom; } set { _bossRoom = value; } }
    protected bool _bossClear;
    public bool BossClear { get { return _bossClear; } set { _bossClear = value; } }
    //현재 바라보고 있는 방향 값을 가진 변수가 필요
    Vector3 dirVec;
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
        Vector2 v2 = new Vector2(PlayerPrefs.GetFloat("savePlayerX"), PlayerPrefs.GetFloat("savePlayerY"));
        transform.position = v2;
    }
    void Update()
    {
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

        if(Input.GetKeyDown(KeyCode.Space)&& _scanObject.CompareTag("Stone"))
        {
            _scanObject.GetComponent<OpenStone>().isPlayerEnter = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _scanObject.CompareTag("Treasure"))
        {
            _scanObject.GetComponent<OpenTreasure>().isPlayerEnter2 = true;
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
    public void postionSet(float x,float y)
    {
        x=transform.position.x; 
        y=transform.position.y;
        PlayerPrefs.SetFloat("playerX",transform.position.x);
        PlayerPrefs.SetFloat("playerY",transform.position.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DungeonDoor"))
        {
            PlayerPrefs.SetFloat("savePlayerX", 0.03f);
            PlayerPrefs.SetFloat("savePlayerY", -5.05f);
            SceneManager.LoadScene("Dungeon");
        }
        if (collision.gameObject.CompareTag("Border"))//Dungeon>>main
        {
            PlayerPrefs.SetFloat("savePlayerX", 2.56f);
            PlayerPrefs.SetFloat("savePlayerY", 1.36f);
            SceneManager.LoadScene("Main");
        }
        if (collision.gameObject.CompareTag("Border1"))//house>>main
        {
            PlayerPrefs.SetFloat("savePlayerX", 11.64f);
            PlayerPrefs.SetFloat("savePlayerY", 0.26f);
            SceneManager.LoadScene("Main");

        }
        if (collision.gameObject.CompareTag("HouseDoor1"))
        {
            PlayerPrefs.SetFloat("savePlayerX", 0.02f);
            PlayerPrefs.SetFloat("savePlayerY", -3.22f);
            SceneManager.LoadScene("House1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossRoom"))
            BossRoom = true;
        if (collision.gameObject.CompareTag("BossClear"))
            BossClear = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossRoom"))
            BossRoom = false;
        if (collision.gameObject.CompareTag("BossClear"))
            BossClear = false;
    }


}