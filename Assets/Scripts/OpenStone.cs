using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStone : MonoBehaviour
{
    public GameObject _player;
    Animator _ani;
    public bool isPlayerEnter;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _ani = GetComponent<Animator>();
        isPlayerEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerEnter==true) 
        {
            _ani.SetTrigger("Open");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //isPlayerEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerEnter = false;

    }

}
