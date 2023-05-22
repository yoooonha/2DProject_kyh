using System.Collections.Generic;
using UnityEngine;


public class OpenStone : MonoBehaviour
{
   // public GameObject _player;
    Animator _ani;
    protected bool _isPlayerEnter;
    public bool isPlayerEnter { get { return _isPlayerEnter; } set { _isPlayerEnter = value; } }
    [SerializeField] GameObject _hpBar;
    [SerializeField] GameObject _moncon;
    void Awake()
    {
        //_player = GameObject.FindGameObjectWithTag("Player");
        //_monster = Resources.Load("Prefabs/Slime") as GameObject; //as GameObject Çüº¯È¯
        _ani = GetComponent<Animator>();
        isPlayerEnter = false;
    }
  
    void Update()
    {
        if (isPlayerEnter == true)
        {
            _ani.SetTrigger("Open");
            makeMonster();
        }

    }
    private void Start()
    {
      
    }

    void makeMonster()
    {
        if (!isPlayerEnter) return;
        int ran = Random.Range(0, 10);
        if (ran<3)
        {
            Debug.Log("Not Monster");
            
        }
        else if (ran<7)
        {
          _moncon.SetActive(true);
            _hpBar.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerEnter = false;

    }

}
