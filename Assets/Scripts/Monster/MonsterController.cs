using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] GameObject[] _mon;
    [SerializeField] Transform _player;
    [SerializeField] OpenStone _os;
    public void Start()
    {
    }
    public Transform getTargetMonster()
    {
        Transform result = null;
        // result�� _mon�迭���� �������� ã�Ƽ� �־��ִ� �ڵ�
        for(int i = 0; i < _mon.Length; i++)
        {
            if (_mon[i].activeSelf == true && Vector3.Distance(_mon[i].transform.position,_player.position)<4.5f)
            {
                result = _mon[i].transform;
            }
          
        }
                return result;
    }
    public void MakeMon()
    {
        for (int i = 0; i < _mon.Length; i++)
        {
            if (_mon[i].gameObject.activeSelf == false)
            {
                Monster newMon= _mon[i].GetComponent<Monster>();
                newMon.Init(this, _player);
            }
        }
    }

}
