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







    public void move()
    {


        Vector2 v2 = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _ani.SetInteger("move", 1);
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
            //v2 += Vector2.right * Time.deltaTime * _speed;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _ani.SetInteger("move", 2);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _ani.SetInteger("move", 3);
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _ani.SetInteger("move", 4);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            _ani.SetInteger("move", 5);
            transform.Translate(Vector2.up * Time.deltaTime * _speed);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _ani.SetInteger("move", 6);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
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
          
        }




    }
}