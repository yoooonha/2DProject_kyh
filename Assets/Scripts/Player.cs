using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    float h;
    float v;
    Rigidbody2D rigid;
    Animator _ani;
    //bool isIdle = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid= GetComponent<Rigidbody2D>();
        _ani= GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(h, v) * _speed;
        
        move();

    }


    void move()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _ani.SetInteger("move", 1);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            _ani.SetInteger("move", 2);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _ani.SetInteger("move", 3);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _ani.SetInteger("move", 4);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _ani.SetInteger("move", 5);
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            _ani.SetInteger("move", 6);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _ani.SetInteger("move", 7);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            _ani.SetInteger("move", 0);
        }


    }
}
