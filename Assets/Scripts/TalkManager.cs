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
        talkData.Add(1000, new string[] { "안녕?", "이 곳은 처음이지?" });// talkindex[0],talkindex[1]
        talkData.Add(2000, new string[] { "오랜만이야!", "날씨가 참 좋구나" });
        //isNpc=false
        talkData.Add(100, new string[] { "※절대 들어가지 마시오※" });
        talkData.Add(200, new string[] { "경고! 쓰레기를 버리지 마세요!" });
        talkData.Add(300, new string[] { "...", "이 곳은 지나갈 수 없어" });

        
    }

    public string GetTalk(int id, int talkindex)
    {
        if (talkindex == talkData[id].Length)
            return null;
        else
        return talkData[id][talkindex]; //id로 대화 가져오기 / talkindex로 대화 한문장 가져오기
    }
}
