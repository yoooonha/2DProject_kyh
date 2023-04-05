using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStone : MonoBehaviour
{
    public GameObject _player;
    Animator _ani;
    bool isPlayerEnter;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _ani = GetComponent<Animator>();
        isPlayerEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerEnter&&Input.GetKeyDown(KeyCode.Space)) 
        {
            _ani.SetTrigger("Open");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _player)
        {
            isPlayerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == _player)
        {
            isPlayerEnter = false;
        }
    }

}
