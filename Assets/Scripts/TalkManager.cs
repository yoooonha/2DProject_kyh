using System.Collections.Generic;
using UnityEngine;


public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] NpcPortrait;
  
    void Awake()//게임오브젝트가 꺼져있어도 실행됨
    {
        talkData = new Dictionary<int, string[]>();//int key에 string배열값을 저장하는 Dictionary함수
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //isNpc=true
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳은 처음이지?:0" });// talkindex[0],talkindex[1]
        talkData.Add(2000, new string[] { "오랜만이야!:1", "날씨가 참 좋구나:1" });
        talkData.Add(3000, new string[] { "안녕:2", "우리집은 처음이지?:2","집 밖은 위험해!:2","무서운 마녀가 잡아갈지도 몰라:2" });


        //isNpc=false
        talkData.Add(100, new string[] { "※경고※","무시무시한 마녀가 살고있어" });
        talkData.Add(200, new string[] { "쓰레기를 버리지 마세요" });
        talkData.Add(300, new string[] { "...", "이 곳은 지나갈 수 없어" });
        talkData.Add(400, new string[] { "...", "안에 아무도 없는거 같다." });

        portraitData.Add(1000+0, NpcPortrait[0]);
        portraitData.Add(2000+1, NpcPortrait[1]);
        portraitData.Add(3000+2, NpcPortrait[2]);
        
        
        //Quest Talk
        talkData.Add(10+1000,new string[] {//퀘스트아이디+npc아이디
                "어서와.:0",
                "이 던전에 놀라운 전설이 있다는데:0",
                "오른쪽 마당집 쪽에 친구가 알려줄꺼야:0"
        });
        talkData.Add(11+2000,new string[] {//퀘스트아이디+npc아이디
                "안녕.:1",
                "던전의 전설을 들으러 온거야?:1",
                "그럼 일 좀 하나 해주면 좋을텐데:1",
                "호수 근처에 반지를 잃어버려서 찾아줬으면 해:1"
        });

        talkData.Add(20 + 1000, new string[]
        {
            "...:0",
            "반지?:0",
            "자기 물건을 흘리고 다니면 못쓰지!:0",
            "나중에 한마디 해야겠어.:0"
        });;

        talkData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘.:1", });
        talkData.Add(20 + 5000, new string[] { "근처에 반지를 찾았다." });

        talkData.Add(21 + 2000, new string[] { "엇 찾아줘서 고마워.:1" });
        
    }
    public Sprite GetPortrait(int id,int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id)) //ContainsKey(): Dictionary에 key가 존재하는지 검사
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

//ContainsKey() : Dictionary에 Key가 존재하는지 검사
// id가 없으면 퀘스트 대화순서 제거 후 재탐색
//21 + 1000 = 1021 / 10 =102.1 1021-1=1020

//id로 대화 가져오기 / talkindex로 대화 한문장 가져오기