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
        //�����ġ - ����ġ
        float angle = Vector2.SignedAngle(Vector2.right, _dir);//������ �˷��� 45~135�� ���� up && -45~-135�� Down check
        Debug.Log("�Ѿ��� ���ư��� ����" + angle);
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        transform.Translate(_dir* Time.deltaTime * _speed, Space.World);
        //Ÿ�ٹ������� rotation z���� ���ư� 
        //_render.flipX= _target.position.x < transform.position.x;
       
    }
}
