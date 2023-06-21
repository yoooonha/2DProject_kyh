using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Transform _player;
    //[SerializeField] GameObject _uiPanel;
    [SerializeField] GameManager manager;
    
    Rigidbody2D rigid;
    Animator _ani;
    GameObject _border;
    GameObject _scanObject;
    GameObject _bullet;
    Vector3 _dir;
    public float _timer = 0f;

    public MonsterController _monCon { get; set;}
    public Slider _Hpbar { get; set; }

    protected bool isGameOver; 
    public bool IsGameOver { get { return isGameOver; } set { isGameOver = value; } }
    protected bool _bossRoom;
    public bool BossRoom { get { return _bossRoom; } set { _bossRoom = value; } }
    protected bool _bossClear;
    public bool BossClear { get { return _bossClear; } set { _bossClear = value; } }
    //현재 바라보고 있는 방향 값을 가진 변수가 필요
    Vector3 dirVec;

    //singleton
    public static Player _instance;
    private void Awake()
    {
       
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HPBar()
    {
       
        _Hpbar.value -= 10f;
    }

    public void Attack()
    {
       
        if (Input.GetKey(KeyCode.A))
        {
            if (_timer > 0.2f)
            {
                SoundController.instance.SFXPlay(SoundController.sfx.Attack);
                Transform target = _monCon.getTargetMonster();
            if (target == null) return;
            GameObject temp = Instantiate(_bullet);
            Vector3 dir = (target.transform.position - transform.position).normalized;//nomalized 크기를 1로 바꿈
            temp.transform.position = transform.position + dir;
            //내위치+나로부터 적까지 방향
            temp.name = "Bullet";
            temp.GetComponent<Bullet>().Init(target);
            _timer = 0f;
            }
        }
    }
    

    public void Hitted(int dmg)
    {
        if (_hp < 0) return;
        _hp -= dmg;
        HPBar();
        if (_hp < 0)
        {
            _Hpbar.value = 0;
            //Game over
            isGameOver = true;
            SoundController.instance.bgmStop();
            SoundController.instance.SFXPlay(SoundController.sfx.GameOver);
            gameObject.SetActive(false);
            //_uiPanel.SetActive(true);
        }
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
    }
    bool sceneChange = true;
    public void positionInit()
    {
        sceneChange = true;
        //씬이 바뀔때마다 호출하여 초기화시켜준다
        Vector2 v2 = new Vector2(PlayerPrefs.GetFloat("savePlayerX"), PlayerPrefs.GetFloat("savePlayerY"));
        transform.position = v2;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        move();
        RayCast();
        Attack();

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
       
    }
    public void move()
    {
        if(isGameOver==true) { return; }
        if (manager.isAction || manager._Action==true) return;
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

    public void playerInit()
    {
        //죽었을때 다시 초기화 세팅
        isGameOver = false;
        gameObject.SetActive(true);
        PlayerPrefs.SetFloat("savePlayerX", 0.03f);
        PlayerPrefs.SetFloat("savePlayerY", -5.05f);
        _hp = 100;
        HPBar();
    }
    public void playerExit()
    {
        //죽었을때 EXIT버튼 눌렀을 때 다시 초기화
        isGameOver = false;
        gameObject.SetActive(true);
        PlayerPrefs.SetFloat("savePlayerX", 5.97f);
        PlayerPrefs.SetFloat("savePlayerY", -1.8f);
       
        _hp = 100;
        HPBar();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("DungeonDoor"))
        {
            PlayerPrefs.SetFloat("savePlayerX", 0.03f);
            PlayerPrefs.SetFloat("savePlayerY", -5.05f);
            sceneChange = false;
            SceneManager.LoadScene("Dungeon");
            positionInit();
        }
        if (collision.gameObject.CompareTag("Border"))//Dungeon>>main
        {
            PlayerPrefs.SetFloat("savePlayerX", 2.56f);
            PlayerPrefs.SetFloat("savePlayerY", 1.36f);
            sceneChange = false;
            SceneManager.LoadScene("Main");
            positionInit();


        }
        if (collision.gameObject.CompareTag("Border1"))//house>>main
        {
            PlayerPrefs.SetFloat("savePlayerX", 11.64f);
            PlayerPrefs.SetFloat("savePlayerY", 0.26f);
            sceneChange = false;
            SceneManager.LoadScene("Main");
            positionInit();



        }
        if (collision.gameObject.CompareTag("HouseDoor1"))
        {
            PlayerPrefs.SetFloat("savePlayerX", 0.02f);
            PlayerPrefs.SetFloat("savePlayerY", -3.22f);
            sceneChange = false;
            SceneManager.LoadScene("House1");
            positionInit();


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