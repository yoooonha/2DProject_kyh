using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject talkPanel;
    public GameObject _scanObject;
    public bool isAction; //���� ����� ����

    public void Action(GameObject sacnObj)
    {
        if (isAction) //�̹� Action�� ������������ 
        {
            isAction= false;
        }
        else
        {

            isAction = true; //�ǳ��� ����.
            _scanObject = sacnObj;//��ĵ�� ������Ʈ�� ������ ��
            talkText.text = "�̰��� �̸���"+ _scanObject.name+"�̶�� �Ѵ�."; //��縦 ����.
        }

        talkPanel.SetActive(isAction);
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
