using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject _balloon;
    [SerializeField] Transform _player;
    float _distance = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "player")
        {
            float dis = Vector2.Distance(_player.position,transform.position);
            if(dis>_distance)
            {
                _balloon.SetActive(false);
            }
            else _balloon.SetActive(true);
        }
    }

}
