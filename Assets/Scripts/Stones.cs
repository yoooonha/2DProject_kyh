using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Stones : MonoBehaviour
{
    [SerializeField] GameObject[] _stones;
    [SerializeField] GameObject _jail;
    [SerializeField] GameObject attackMode;
    [SerializeField] GameObject[] _mons;

    private void Update()
    {
        //문이 열려있을 때 return
        if (_jail.activeSelf == false) return;
        bool isAllNull = true;
        for(int i=0;i<_stones.Length;i++)
        {
            // 전부 null
            if (_stones[i].activeSelf == true)
            {
                isAllNull = false;
                break;//빠져나간다
            }
        }
        if (isAllNull == false) return;
        bool isallOff = true;
        for(int i=0;i<_mons.Length;i++)
        {
            // 전부꺼졌으면
            if (_mons[i].activeSelf == true)
            {
                isallOff = false;
                break;
            }
        }
        if (isallOff == false) return;
        //문을 열어줍니다.
        _jail.SetActive(false);
    }
}



