using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreasure : MonoBehaviour
{
    [SerializeField] GameObject _player;
    Animator _ani;
    protected bool _isPlayerEnter2;
    public bool isPlayerEnter2 { get { return _isPlayerEnter2; }set { _isPlayerEnter2 = value; } }
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _ani=GetComponent<Animator>();
        isPlayerEnter2=false;
    }

    void Update()
    {
        if (isPlayerEnter2 == true)
        {
            _ani.SetTrigger("OpenTreasure");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isPlayerEnter2 = false;
    }
}
