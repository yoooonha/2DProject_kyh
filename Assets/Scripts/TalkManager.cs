using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Sprites;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite[]> ImageData;

    public Sprite[] NpcImage;
  
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        ImageData = new Dictionary<int, Sprite[]>();

        GenerateData();
    }

    void GenerateData()
    {
        //isNpc=true
        talkData.Add(1000, new string[] { "�ȳ�?", "�� ���� ó������?" });// talkindex[0],talkindex[1]
        talkData.Add(2000, new string[] { "�������̾�!", "������ �� ������" });
        //isNpc=false
        talkData.Add(100, new string[] { "������ ���� ���ÿ���" });
        talkData.Add(200, new string[] { "���! �����⸦ ������ ������!" });
        talkData.Add(300, new string[] { "...", "�� ���� ������ �� ����" });

        
    }

    public string GetTalk(int id, int talkindex)
    {
        if (talkindex == talkData[id].Length)
            return null;
        else
        return talkData[id][talkindex]; //id�� ��ȭ �������� / talkindex�� ��ȭ �ѹ��� ��������
    }
}
