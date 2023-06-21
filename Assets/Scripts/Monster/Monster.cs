using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] int _attack;
    //player
    //[SerializeField] Player _player;
     Transform _target;//Player



    [SerializeField][Range(0f, 3f)] float contactDistance;
    [SerializeField] Zone _zone;
    [SerializeField] SpriteRenderer _img;
    [SerializeField] Animator _ani2;
    [SerializeField] Slider _slider;
    [SerializeField] GameObject _AttackMode;
    [SerializeField] MonsterController _mc;

    bool isHitted = false;
    bool isAttack = false;
    protected bool isLive=true;//몬스터가 살아있는지 죽었는지
    public bool IsLive { get { return isLive; } set { isLive = value; } }
    float _timer;
    //public GameObject _excam;
    Rigidbody2D _rigid;
    Animator _ani;
    SpriteRenderer _render;


    void Start()
    {
        _rigid=GetComponent<Rigidbody2D>();
        _render = GetComponent<SpriteRenderer>();
        _ani= GetComponent<Animator>();

        _target = Player._instance.transform;
    }

    void Update()
    {
        move();
        colorChange();
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
    public void HpBar()
    {
        _slider.value -= 0.1f;
        if(_slider.value == 0)
        {
            _AttackMode.SetActive(false);
            _slider.value = 1;
        }
    }
    public void onHitted(int hitpower)
    {
        _hp -= hitpower;
        isHitted = true;
        if (_hp == 0)
        {
            isLive = false;
            HpBar();
            SoundController.instance.SFXPlay(SoundController.sfx.SlimeDeath);
            _ani.SetTrigger("Dead");
            Invoke("Remove", 1f);
        }
    }
    void Remove()
    {
        gameObject.SetActive(false);
        //_mc.MakeMon();

    }
    void colorChange()
    {
        if (isHitted == true)
        {
            _timer += Time.deltaTime;
            _render.color = Color.red;
            if (_timer > 0.5f)
            {
                //초기화
                isHitted = false;
                _render.color = Color.white;
                _timer = 0f;
            }
        }

    }
    public void Attack()//몬스터 공격 애니메이션 이벤트 함수
    {
        Player._instance.Hitted(10);
        SoundController.instance.SFXPlay(SoundController.sfx.SlimeAttack);
        //_player.GetComponent<Player>().Hitted(10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "Player"))
        {
            isAttack = true;
            _ani.SetBool("Attack", true);
        }
        if (collision.gameObject.GetComponent<Damage>() != null)
        {
            int damage = collision.gameObject.GetComponent<Damage>().getDamage();
            collision.gameObject.GetComponent<BulletRemove>().Remove();
            onHitted(damage);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _ani.SetBool("Attack", false);
    }
   public void Init(MonsterController mc,Transform Player)
    {
        gameObject.SetActive(true);
        _mc = mc;
        _target = Player;
        //다시 나타났을때 초기화
        _hp = 10;
        HpBar();
        Vector3 ranPos = _target.position + new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(-1.2f, 1.2f)).normalized*1.5f;
        transform.position = ranPos;
        isLive = true;
    }
}
