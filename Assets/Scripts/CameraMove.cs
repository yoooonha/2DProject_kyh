using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _Cam;
    [SerializeField] Player _Player;
    public GameObject _bosRoom;
    public GameObject _bosClear;

    void Update()
    {
        if (_Player.BossRoom == true)
        {
            _Cam.position = Vector3.Lerp(_Cam.position, new Vector3(0, 9.95f, -10), 0.007f);
            Invoke("objOff", 1f);
            
        }
        if (_Player.BossClear == true)
        {
            _Cam.position = Vector3.Lerp(_Cam.position, new Vector3(0, -0.28f, -10), 0.007f);
        }

    }
    void objOff()
    {
        _bosRoom.SetActive(false);
        _bosClear.SetActive(true);
    }
}
