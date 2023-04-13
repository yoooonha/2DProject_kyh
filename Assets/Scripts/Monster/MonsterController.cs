using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _monCon;
    GameObject _monster;
    List<Monster> mons = new List<Monster>();

    void Start()
    {
        _monster = Resources.Load("Prefabs/Slime") as GameObject; //as GameObject Çüº¯È¯
    }

   //void makeMonster()
   // {
   //     for(int i=0;i<10;i++)
   //     {
   //         GameObject mon = Instantiate(_monster, transform);
   //         mons.Add(mon.GetComponent<Monster>());
   //         foreach(Monster m in mons)
   //         {
   //             m.Init(this, _player);
   //         }
   //     }
   // }
}
