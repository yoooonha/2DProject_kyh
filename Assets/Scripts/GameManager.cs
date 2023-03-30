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

    public bool isAction; //���� ����� ����
    public bool _Action; //���� ����� ����
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
        if(_menuSet.activeSelf) // �ɼ�â�� �̹� �������� ��
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
            talkIndex=0;// ��ȭ�� ������ �� 0���� �ʱ�ȭ
            questText.text = questManager.CheckQuest(id);
            Debug.Log(questManager.CheckQuest(id)); 
            return;
        }
        if( isNpc )
        {
            talkText.text = talkData.Split(':')[0];//�����ڸ� ���Ͽ� �迭�� �����ִ� ���ڿ� �Լ�
            portraitImg.sprite = _talkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));//int.Parse() ���ڿ��� �ش� Ÿ������ ��ȯ���ִ� �Լ�
           portraitImg.color = new Color(1, 1, 1, 1); //NPC�϶��� �̹����� ���̵��� �ۼ�

        }
        else
        {
            talkText.text = talkData;

           portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction= true;
        talkIndex++; //������������ �Ѿ

    }

    public void gameExit()
    {
       // Application.Quit(); //��������
        SceneManager.LoadScene("Lobby");
    }

    public void gameSave()
    {
        //quest id
        //quest action Index
        //player.x
        //player.y
        //������ ������ ���� ����� �����ϴ� Ŭ����
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.x); 
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        _menuSet.SetActive(false);
    }

    public void gameLoad()
    {
        if (PlayerPrefs.HasKey("PlayerX")) //�ѹ��̶� ������ ��������
            return; // ���Ӻҷ����� ����
        //���� �ҷ�����
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
