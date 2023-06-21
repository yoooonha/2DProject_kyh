using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;//지금 진행중인 퀘스트아이디
    public int questActionIndex; //퀘스트 대화순서 변수 
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList; //퀘스트 데이터를 저장할 Dictionary 변수 생성
        void Awake()
    {
        //int key에 QuestData값을 저장하는 Dictionary 함수
        questList = new Dictionary<int, QuestData>();//초기화
        GenerateData();

    }

    public void GenerateData()
    {
        questList.Add(10, new QuestData("마을 사람들과 대화하기",new int[] {1000,2000}));
        questList.Add(20, new QuestData("NPC2의반지 찾아주기",new int[] {5000,2000}));
        questList.Add(30, new QuestData("퀘스트 올 클리어!", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)//NPC id를 받고 퀘스트번호를 반환하는 함수 생성
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id) //대화가 끝났을 때
    {


        if(id == questList[questId].npcId[questActionIndex]) //
        questActionIndex++; //questid = 11

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length) //Npc와 대화를 다 나누었을때 다음 퀘스트 실행
            NextQuest();

        return questList[questId].questName; //현재 퀘스트 이름 확인
    }

    public void NextQuest()
    {
        questId += 10; 
        questActionIndex = 0; //새로운 퀘스트가 시작되기때문에 0으로 초기화시킴
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
                if (questActionIndex == 1 ) //ring 먹었을때
                    questObject[0].SetActive(false);
                SoundController.instance.SFXPlay(SoundController.sfx.GetItem);
                //Destroy(questObject[0]);
                break;
        }
    }

}

public class QuestData
{
    public string questName;//생성자의 변수.. 필드
    public int[] npcId;

    public QuestData(string name, int[] npc) //생성자
    {
        questName = name;
        npcId = npc;
    }
}


