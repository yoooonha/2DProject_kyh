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
    

    bool isLive=true;//몬스터가 살아있는지 죽었는지
    bool follow;
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
        if (Vector2.Distance(transform.position, _target.position) > contactDistance && follow)
        {
            transform.Translate((_target.position - transform.position).normalized * Time.deltaTime * _speed);
            _render.flipX = _target.position.x > transform.position.x;
        }
        else
            _rigid.velocity = Vector2.zero;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
        _ani.SetBool("Move", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        follow= false;
        _ani.SetBool("Move", false);

    }
}
