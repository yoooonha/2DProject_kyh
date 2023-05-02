using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class OpenStone : MonoBehaviour
{
    public GameObject _player;
    Animator _ani;
    public bool isPlayerEnter;
    GameObject _monster;
    List<Monster> monsters = new List<Monster>();
    [SerializeField] GameObject _hpBar;
    [SerializeField] GameObject _moncon;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _monster = Resources.Load("Prefabs/Slime") as GameObject; //as GameObject Çüº¯È¯
        _ani = GetComponent<Animator>();
        isPlayerEnter = false;
    }
    private void Start()
    {
       

    }
    void Update()
    {
        if(isPlayerEnter==true) 
        {
            _ani.SetTrigger("Open");
           makeMonster();
        }

    }
    

    void makeMonster()
    {
        if (!isPlayerEnter) return;
        int ran = Random.Range(0, 10);
        if (ran<3)
        {
            Debug.Log("Not Monster");
            
        }
        else if (ran<5)
        {
          _moncon.SetActive(true);
            _hpBar.SetActive(true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerEnter = false;

    }

}
