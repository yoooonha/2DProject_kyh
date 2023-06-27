using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Transform _target=null;
    Vector3 _dir;
    public void bossInit(Transform target)
    {
        _target = target;
        _dir=(_target.position - transform.position).normalized;
    }
    void Start()
    {
        
    }

    void Update()
    {
        float angle=Vector2.SignedAngle(Vector2.right, _dir);
        //Debug.Log("�÷��̾� �ٶ󺸴� ���� "+angle);
        //Down
        //-45~-135��
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(_dir * Time.deltaTime * _speed, Space.World);
    }
}
