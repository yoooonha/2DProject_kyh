using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;//���� �������� ����Ʈ���̵�
    public int questActionIndex; //����Ʈ ��ȭ���� ���� 
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList; //����Ʈ �����͸� ������ Dictionary ���� ����
        void Awake()
    {
        //int key�� QuestData���� �����ϴ� Dictionary �Լ�
        questList = new Dictionary<int, QuestData>();//�ʱ�ȭ
        GenerateData();

    }

    public void GenerateData()
    {
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�",new int[] {1000,2000}));
        questList.Add(20, new QuestData("NPC2�ǹ��� ã���ֱ�",new int[] {5000,2000}));
        questList.Add(30, new QuestData("����Ʈ �� Ŭ����!", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)//NPC id�� �ް� ����Ʈ��ȣ�� ��ȯ�ϴ� �Լ� ����
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id) //��ȭ�� ������ ��
    {


        if(id == questList[questId].npcId[questActionIndex]) //
        questActionIndex++; //questid = 11

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length) //Npc�� ��ȭ�� �� ���������� ���� ����Ʈ ����
            NextQuest();

        return questList[questId].questName; //���� ����Ʈ �̸� Ȯ��
    }

    public void NextQuest()
    {
        questId += 10; 
        questActionIndex = 0; //���ο� ����Ʈ�� ���۵Ǳ⶧���� 0���� �ʱ�ȭ��Ŵ
    }

    public void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1 ) //ring �Ծ�����
                    questObject[0].SetActive(false);
                SoundController.instance.SFXPlay(SoundController.sfx.GetItem);
                //Destroy(questObject[0]);
                break;
        }
    }

}

public class QuestData
{
    public string questName;//�������� ����.. �ʵ�
    public int[] npcId;

    public QuestData(string name, int[] npc) //������
    {
        questName = name;
        npcId = npc;
    }
}


