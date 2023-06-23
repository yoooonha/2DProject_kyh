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
        float angle = Vector2.SignedAngle(Vector2.right, _dir);//각도를 알려줌 45~135도 사이 up && -45~-135도 Down check
        Debug.Log("총알이 날아가는 각도" + angle);
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        transform.Translate(_dir* Time.deltaTime * _speed, Space.World);
        //타겟방향으로 rotation z축이 돌아감 
        //_render.flipX= _target.position.x < transform.position.x;
       
    }
}
