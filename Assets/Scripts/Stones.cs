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
        //���� �������� �� return
        if (_jail.activeSelf == false) return;
        bool isAllNull = true;
        for(int i=0;i<_stones.Length;i++)
        {
            // ���� null
            if (_stones[i].activeSelf == true)
            {
                isAllNull = false;
                break;//����������
            }
        }
        if (isAllNull == false) return;
        bool isallOff = true;
        for(int i=0;i<_mons.Length;i++)
        {
            // ���β�������
            if (_mons[i].activeSelf == true)
            {
                isallOff = false;
                break;
            }
        }
        if (isallOff == false) return;
        //���� �����ݴϴ�.
        _jail.SetActive(false);
    }
}



