using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public tileManager tileManager;

    //대화장 UI
    public TalkManager talkManager;
    public GameObject talkPanel;
    //public Image portraitImg;
    public Text talkText;
    public GameObject scanObject;
    public bool talkAction;
    public int talkIndex;

    private void Awake()
    {
        //다른 씬으로 넘어가도 GameManager가 파괴되지 않도록 관리
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        //tileManager 셋업
        tileManager = GetComponent<tileManager>();

        talkPanel.SetActive(false);
    }

    //대화 이벤트
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);
        talkPanel.SetActive(talkAction);//대화창 show & hide
    }

    //대화 구현
    void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex); //대화 대사 받기

        if (talkData == null)
        {
            talkAction = false;
            talkIndex = 0;
            return; //함수 종료
        }

        talkText.text = talkData;
        //portraitImg.color = new Color(1, 1, 1, 1);

        talkAction = true;
        talkIndex++;
    }
}
