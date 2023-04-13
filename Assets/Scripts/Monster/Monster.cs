using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Monster : MonoBehaviour
{
    public float _speed;
    public int _hp;
    [SerializeField] Transform _target;//target
    [SerializeField][Range(0f, 3f)] float contactDistance;
    public float findDistance;
    [SerializeField] Zone _zone;

    public GameObject _excam;
    [SerializeField] SpriteRenderer _img;
    [SerializeField] Animator _ani2;
    

    bool isLive=true;//���Ͱ� ����ִ��� �׾�����
    //bool follow;
    MonsterController _mc;
    Rigidbody2D _rigid;
    Animator _ani;
    SpriteRenderer _render;

    void Start()
    {
        _rigid=GetComponent<Rigidbody2D>();
        _render = GetComponent<SpriteRenderer>();
        _ani= GetComponent<Animator>();
    }

    void Update()
    {
        move();
        
     

    }



    void move()
    {
        if (!isLive)
            return;
        if(Vector2.Distance(transform.position, _target.position) < contactDistance)
        {
            _img.color=new Color(255,255,255,255);
            _ani2.SetBool("Find", true);
            Invoke("targetMove", 0.7f);
       
        }
        else
        {
            _img.color = new Color(255, 255, 255, 0);
            _zone.follow=false;
            _ani.SetBool("Move", false);
            _rigid.velocity = Vector2.zero;

        }
    }

    void targetMove()
    {
        _zone.follow=true;
        _ani.SetBool("Move", true);
        transform.Translate((_target.position - transform.position).normalized * Time.deltaTime * _speed);
        _render.flipX = _target.position.x > transform.position.x;
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.name == "Player")) return;
        {
            _ani.SetBool("Attack",true);
            _img.color = new Color(255, 255, 255, 0);
        } 
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _ani.SetBool("Attack", false);


    }




}
