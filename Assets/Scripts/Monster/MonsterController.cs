using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] GameObject[] _mon;
    [SerializeField] OpenStone _os;
    Transform _player;
    private void Start()
    {
        _player = Player._instance.transform;
        Player._instance._monCon = this;
    }
    public Transform getTargetMonster()
    {
        Transform result = null;
        // result에 _mon배열에서 안죽은애 찾아서 넣어주는 코드
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
