using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] GameObject _option;

    Rigidbody2D rigid;
    Animator _ani;

    GameObject _border;
    GameObject _scanObject;
    public GameManager manager;
    //현재 바라보고 있는 방향 값을 가진 변수가 필요
    Vector3 dirVec;

    //bool isIdle = true;

    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        

    }
    // Update is called once per frame
    void Update()
    {
        
        move();


        RayCast();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _option.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && Input.GetKeyUp(KeyCode.Escape))
        {
            _option.SetActive(false);
            Time.timeScale = 1;
        }



     
    }

    void RayCast()
    {
        //스캔할 수 있다
        Debug.DrawRay(rigid.position, dirVec * 0.8f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.8f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            _scanObject = rayHit.collider.gameObject;
        }
        else
        {
            _scanObject = null;
        }
        if (Input.GetKey(KeyCode.Space)&&_scanObject!=null)
        {
            manager.Action(_scanObject);
        }
     
        

    }
    





    public void move()
    {


        Vector2 v2 = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //manager.isAction = false;
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
        if (collision.gameObject.tag == "Border")
        {
            SceneManager.LoadScene("Main");
            transform.position = new Vector3(2.5f, 1.5f, 0);
        }
        if(collision.gameObject.tag== "HouseDoor1")
        {
            SceneManager.LoadScene("House1");
        }




    }
}