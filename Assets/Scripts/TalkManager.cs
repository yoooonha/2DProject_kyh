using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] NpcPortrait;
  
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //isNpc=true
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó������?:0" });// talkindex[0],talkindex[1]
        talkData.Add(2000, new string[] { "�������̾�!:1", "������ �� ������:1" });


        //isNpc=false
        talkData.Add(100, new string[] { "�ع��ù����� ���డ ����־�!��" });
        talkData.Add(200, new string[] { "���! �����⸦ ������ ������!" });
        talkData.Add(300, new string[] { "...", "�� ���� ������ �� ����" });

        portraitData.Add(1000+0, NpcPortrait[0]);
        portraitData.Add(2000+1, NpcPortrait[1]);
        portraitData.Add(3000+2, NpcPortrait[2]);
        
        
        //Quest Talk
        talkData.Add(10+1000,new string[] {//����Ʈ���̵�+npc���̵�
                "���.:0",
                "�� ������ ���� ������ �ִٴµ�:0",
                "������ ������ �ʿ� ģ���� �˷��ٲ���:0"
        });
        talkData.Add(11+2000,new string[] {//����Ʈ���̵�+npc���̵�
                "�ȳ�.:1",
                "������ ������ ������ �°ž�?:1",
                "�׷� �� �� �ϳ� ���ָ� �����ٵ�:1",
                "������ ������ �ΰ�ͼ� ã�������� ��:1"
        });

        talkData.Add(20 + 3000, new string[]
        {
            "�絵�� ����?:2",
            "�ڱ� ������ �긮�� �ٴϸ� ������!:2",
            "���߿� �Ѹ��� �ؾ߰ھ�.:2"
        });

        talkData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��.:1", });
        talkData.Add(20 + 5000, new string[] { "��ó�� ������ ã�Ҵ�." });

        talkData.Add(21 + 2000, new string[] { "�� ã���༭ ����.:1" });
        
    }
    public Sprite GetPortrait(int id,int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id)) //ContainsKey(): Dictionary�� key�� �����ϴ��� �˻�
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); //Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex);
        }


        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

    }
            
    }

//ContainsKey() : Dictionary�� Key�� �����ϴ��� �˻�
// id�� ������ ����Ʈ ��ȭ���� ���� �� ��Ž��
//21 + 1000 = 1021 / 10 =102.1 1021-1=1020

//id�� ��ȭ �������� / talkindex�� ��ȭ �ѹ��� ��������