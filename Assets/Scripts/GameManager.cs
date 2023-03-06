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

    public void Action(GameObject sacnObj)
    {
        if (isAction) //이미 Action이 취해져있으면 
        {
            isAction= false;
        }
        else
        {

            isAction = true; //판넬을 띄운다.
            _scanObject = sacnObj;//스캔한 오브젝트를 저장한 뒤
            talkText.text = "이것의 이름은"+ _scanObject.name+"이라고 한다."; //대사를 띄운다.
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
