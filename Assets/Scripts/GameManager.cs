using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public Text questText;

    public Image portraitImg;

    public GameObject talkPanel;
    public GameObject _scanObject;
    public GameObject _menuSet;
    public GameObject _player;

    public QuestManager questManager;
    public TalkManager _talkManager;

    public bool isAction; //상태 저장용 변수
    public bool _Action; //상태 저장용 변수
    int talkIndex;

    private void Start()
    {
        gameLoad();
        //questTalk.text = questManager.CheckQuest();
    }

    private void Update()
    {
        //Sub menu
        if (Input.GetKeyUp(KeyCode.Escape))
        {
        if(_menuSet.activeSelf) // 옵션창이 이미 켜져있을 때
            {
                _menuSet.SetActive(false);
            Time.timeScale = 1;
                _Action = false;
               
            }
            else
            {
            _menuSet.SetActive(true);
            Time.timeScale = 0;
                _Action = true;
            }
        }

    }
    public void Action(GameObject sacnObj)
    {
        _scanObject = sacnObj;
        objData _objData = _scanObject.GetComponent<objData>();
        Talk(_objData.id, _objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {

        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = _talkManager.GetTalk(id+ questTalkIndex, talkIndex);
        //End Talk
        if (talkData == null ) {
            isAction= false;
            talkIndex=0;// 대화가 끝났을 때 0으로 초기화
            questText.text = questManager.CheckQuest(id);
            Debug.Log(questManager.CheckQuest(id)); 
            return;
        }
        if( isNpc )
        {
            talkText.text = talkData.Split(':')[0];//구분자를 통하여 배열로 나눠주는 문자열 함수
            portraitImg.sprite = _talkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));//int.Parse() 문자열을 해당 타입으로 변환해주는 함수
           portraitImg.color = new Color(1, 1, 1, 1); //NPC일때만 이미지가 보이도록 작성

        }
        else
        {
            talkText.text = talkData;

           portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction= true;
        talkIndex++; //다음문장으로 넘어감

    }

    public void gameExit()
    {
       // Application.Quit(); //게임종료
        SceneManager.LoadScene("Lobby");
    }

    public void gameSave()
    {
        //quest id
        //quest action Index
        //player.x
        //player.y
        //간단한 데이터 저장 기능을 지원하는 클래스
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.x); 
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        _menuSet.SetActive(false);
    }

    public void gameLoad()
    {
        if (PlayerPrefs.HasKey("PlayerX")) //한번이라도 저장을 안했으면
            return; // 게임불러오지 말것
        //게임 불러오기
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        _player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();

    }
}
