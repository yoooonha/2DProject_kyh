using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _Cam;
   
    public GameObject _bosRoom;
    public GameObject _bosClear;
    Player _player;
    private void Start()
    {
       _player= Player._instance.GetComponent<Player>();
    }
    void Update()
    {
        if (_player.BossRoom == true)
        {
            _Cam.position = Vector3.Lerp(_Cam.position, new Vector3(0, 9.95f, -10), 0.007f);
            Invoke("objOff", 1f);
            
        }
        if (_player.BossClear == true)
        {
            _Cam.position = Vector3.Lerp(_Cam.position, new Vector3(0, -0.28f, -10), 0.007f);
            StartCoroutine(OnOff(_bosRoom));
        }

    }
    void objOff()
    {
        _bosRoom.SetActive(false);
        _bosClear.SetActive(true);
    }

    IEnumerator OnOff(GameObject room)
    {
        room.SetActive(true);
        new WaitForSeconds(1f);
        yield return null;
    }
}
