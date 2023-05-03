using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemove : MonoBehaviour
{
    float _timer = 0f;
   
    public void Remove()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 5f)
        {
            Remove();
        }
    }
}
