using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Transform _target = null;
    Vector3 _dir;
    SpriteRenderer _render;
    float _timer = 0f;
   
    public void Init(Transform target)
    {
        _target = target;
        _dir=(_target.position-transform.position).normalized;
    }
    
    private void Start()
    {
        _render= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //대상위치 - 내위치
        transform.Translate(_dir* Time.deltaTime * _speed);
        //타겟방향으로 rotation z축이 돌아감 
        _render.flipX= _target.position.x < transform.position.x;
       
    }
}
