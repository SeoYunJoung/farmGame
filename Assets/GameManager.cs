using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public tileManager tileManager;

    //��ȭ�� UI
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Image portraitImg;
    public Text talkText;
    public GameObject scanObject;
    public bool talkAction;
    public int talkIndex;

    private void Awake()
    {
        //�ٸ� ������ �Ѿ�� GameManager�� �ı����� �ʵ��� ����
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        //tileManager �¾�
        tileManager = GetComponent<tileManager>();

        talkPanel.SetActive(false);
    }

    //��ȭ �̺�Ʈ
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);
        talkPanel.SetActive(talkAction);//��ȭâ show & hide
    }

    //��ȭ ����
    void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex); //��ȭ ��� �ޱ�

        if (talkData == null)
        {
            talkAction = false;
            talkIndex = 0;
            return; //�Լ� ����
        }

        talkText.text = talkData;
        //portraitImg.color = new Color(1, 1, 1, 1);

        talkAction = true;
        talkIndex++;
    }
}
