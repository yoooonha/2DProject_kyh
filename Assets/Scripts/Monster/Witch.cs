using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum EBossState
{
    Idle,
    Attack,
    Hitted,
    Die,
}
public class Witch : MonoBehaviour
{
    Animator _ani;
    Transform _player;
    SpriteRenderer _render;
    bool _isAttack = false;
    bool _isHitted;
    bool _isDead;
    int _hpMax;
    [SerializeField] int _hp;
    [SerializeField] float _speed;
    [SerializeField] GameObject _bossBullet;
    [SerializeField] Slider _slider;
    Coroutine _routin;

    public EBossState _estate = EBossState.Idle;
    void Start()
    {
        _ani = GetComponent<Animator>();
        _player = Player._instance.transform;
        _render = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Boss"), LayerMask.NameToLayer("BossBullet"));

    }


    void Update()
    {
        switch (_estate)
        {
            case EBossState.Idle:
                _isAttack = false;
                Move();
                break;
            case EBossState.Attack:
                Attack();
                break;
        }

    }
    void Attack()
    {
        if (_isAttack == false)
        {
            _isAttack = true;
            _routin = StartCoroutine(CoinfiniteMultiShot());
        }
    }
    IEnumerator CoinfiniteMultiShot()
    {
        while (true)
        {
            //Debug.Log("Attack");
            Transform target = _player;
            GameObject Temp = Instantiate(_bossBullet);
            Vector3 dir = (target.position - _player.position).normalized * 1.5f;
            Temp.transform.position = transform.position + dir;
            Temp.GetComponent<BossBullet>().bossInit(target);
            if ((Vector2.Distance(transform.position, _player.position) > 3))
            {
                _estate = EBossState.Idle;
                if (_routin != null) StopCoroutine(_routin);
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Move()
    {
        //Debug.DrawLine(transform.position, _player.position);
        //거리가 10 이상일때 Idle
        // 거리가 3이상일때만 move
        // 이하가 되는순간 attack
        float angle = Vector2.SignedAngle(Vector2.right, (_player.position - transform.position).normalized);
        Debug.Log("마녀가 플레이어를 바라보는 각도 " + angle);
        if (Vector2.Distance(transform.position, _player.position) > 15)
        {
            //Debug.Log("거리가 "+Vector2.Distance(transform.position, _player.position));
            _estate = EBossState.Idle;
            _ani.Play("Down");

        }
        else if (Vector2.Distance(transform.position, _player.position) < 8)
        {
            //Attack
            if ((Vector2.Distance(transform.position, _player.position) <= 3))
            {
                _estate = EBossState.Attack;
            }
            else
            {
                _estate = EBossState.Idle;
                if (_routin != null) StopCoroutine(_routin);
                //Debug.Log("근접거리가 " + Vector2.Distance(transform.position, _player.position));
                transform.Translate((_player.position - transform.position).normalized * _speed * Time.deltaTime);

                if (angle > 45 && angle < 135) _ani.Play("Up");
                else if (angle < -45 && angle > -135) _ani.Play("Down");
                else if (_player.position.x > transform.position.x) _ani.Play("Right");
                else if (_player.position.x < transform.position.x) _ani.Play("Left");
            }

            //else if (_player.position.y < transform.position.y) _ani.Play("Down");
            //else if (_player.position.y > transform.position.y) _ani.Play("Up");
            //if(Vector2.Distance(_player.position, _player.position)<5)
            //    _estate= EBossState.Attack;
            //Debug.Log("Attack");           
        }

    }

    public void BossHpBar()
    {
        _slider.value -= 2;

        if (_slider.value == 0)
        {
        }
    }
    public void OnHitted(int dmg)
    {
        _hp -= dmg;
        _isHitted = true;
        if (_hp == 0)
        {
            _estate = EBossState.Die;

        }

    }
}
