using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject talkPanel;
    public GameObject _scanObject;
    public bool isAction; //상태 저장용 변수
   public TalkManager _talkManager;
    int talkindex;

    public void Action(GameObject sacnObj)
    {
        _scanObject = sacnObj;
        objData _objData = _scanObject.GetComponent<objData>();
        Talk(_objData.id, _objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = _talkManager.GetTalk(id, talkindex);
        if(talkData == null ) {
            isAction= false;
            talkindex=0;// 대화가 끝났을 때 0으로 초기화
            return;
        }
        if( isNpc )
        {
            talkText.text = talkData;

        }
        else
        {
            talkText.text = talkData;
        }
        isAction= true;
        talkindex++; //다음문장으로 넘어감

    }
}
